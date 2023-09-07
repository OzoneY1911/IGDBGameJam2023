using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeBridge : MonoBehaviour
{
    public Transform startPoint;
    public Transform endPoint;

    LineRenderer lineRenderer;
    List<RopeSegment> ropeSegments = new List<RopeSegment>();
    float ropeSegLen = 0.25f;
    int segmentCount = 10;
    float lineWidth = 0.1f;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        Vector3 ropeStartPoint = startPoint.position;

        for (int i = 0; i < segmentCount; i++)
        {
            ropeSegments.Add(new RopeSegment(ropeStartPoint));
            ropeStartPoint.y -= ropeSegLen;
        }
    }

    void Update()
    {
        DrawRope();
    }

    void FixedUpdate()
    {
        Simulate();
    }

    void Simulate()
    {
        Vector2 forceGravity = new Vector2(0f, -1f);

        for (int i = 1; i < segmentCount; i++)
        {
            RopeSegment firstSegment = ropeSegments[i];
            Vector2 velocity = firstSegment.posNow - firstSegment.posOld;
            firstSegment.posOld = firstSegment.posNow;
            firstSegment.posNow += velocity;
            firstSegment.posNow += forceGravity * Time.fixedDeltaTime;
            ropeSegments[i] = firstSegment;
        }

        for (int i = 0; i < 50; i++)
        {
            ApplyConstraint();
        }
    }

    void ApplyConstraint()
    {
        // Constraint to First Point 
        RopeSegment firstSegment = ropeSegments[0];
        firstSegment.posNow = startPoint.position;
        ropeSegments[0] = firstSegment;


        // Constraint to Second Point 
        RopeSegment endSegment = ropeSegments[ropeSegments.Count - 1];
        endSegment.posNow = endPoint.position;
        ropeSegments[ropeSegments.Count - 1] = endSegment;

        for (int i = 0; i < segmentCount - 1; i++)
        {
            RopeSegment firstSeg = ropeSegments[i];
            RopeSegment secondSeg = ropeSegments[i + 1];

            float dist = (firstSeg.posNow - secondSeg.posNow).magnitude;
            float error = Mathf.Abs(dist - ropeSegLen);
            Vector2 changeDir = Vector2.zero;

            if (dist > ropeSegLen)
            {
                changeDir = (firstSeg.posNow - secondSeg.posNow).normalized;
            }
            else if (dist < ropeSegLen)
            {
                changeDir = (secondSeg.posNow - firstSeg.posNow).normalized;
            }

            Vector2 changeAmount = changeDir * error;
            if (i != 0)
            {
                firstSeg.posNow -= changeAmount * 0.5f;
                ropeSegments[i] = firstSeg;
                secondSeg.posNow += changeAmount * 0.5f;
                ropeSegments[i + 1] = secondSeg;
            }
            else
            {
                secondSeg.posNow += changeAmount;
                ropeSegments[i + 1] = secondSeg;
            }
        }
    }

    void DrawRope()
    {
        float lineWidth = this.lineWidth;
        lineRenderer.startWidth = lineWidth;
        lineRenderer.endWidth = lineWidth;

        Vector3[] ropePositions = new Vector3[segmentCount];
        for (int i = 0; i < segmentCount; i++)
        {
            ropePositions[i] = ropeSegments[i].posNow;
        }

        lineRenderer.positionCount = ropePositions.Length;
        lineRenderer.SetPositions(ropePositions);
    }

    public struct RopeSegment
    {
        public Vector2 posNow;
        public Vector2 posOld;

        public RopeSegment(Vector2 pos)
        {
            posNow = pos;
            posOld = pos;
        }
    }
}