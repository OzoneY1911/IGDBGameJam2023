using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rope2D : MonoBehaviour
{
    [SerializeField] Transform ropeOrigin;

    LineRenderer lineRenderer;
    List<RopeSegment> ropeSegments = new List<RopeSegment>();
    float ropeSegLen = 0.25f;
    int segmentCount = 10;
    float lineWidth = 0.1f;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        Vector3 ropeStartPOint = ropeOrigin.position;

        for (int i = 0; i < segmentCount; i++)
        {
            ropeSegments.Add(new RopeSegment(ropeStartPOint));
            ropeStartPOint.y -= ropeSegLen;
        }
    }

    void Update()
    {
        DrawRope();
    }

    void DrawRope()
    {
        float lineWidth = this.lineWidth;
        lineRenderer.startWidth = lineWidth;
        lineRenderer.endWidth = lineWidth;

        Vector3[] ropePositions = new Vector3[segmentCount];
        for (int i = 0;i < segmentCount;i++)
        {
            ropePositions[i] = ropeSegments[i].posCurrent;
        }

        lineRenderer.positionCount = ropePositions.Length;
        lineRenderer.SetPositions(ropePositions);
    }

    struct RopeSegment
    {
        public Vector2 posCurrent;
        public Vector2 posOld;

        public RopeSegment(Vector2 pos)
        {
            this.posCurrent = pos;
            this.posOld = pos;
        }
    }
}
