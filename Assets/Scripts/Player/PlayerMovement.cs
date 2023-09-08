using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    internal static PlayerMovement instance;

    [SerializeField] GameObject arcCenter;
    Quaternion originalRotation;

    [SerializeField] float rotationSpeed = 0.25f;

    float rotationAngle = 0;
    float maximalAngle = 60;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        originalRotation = transform.rotation;
    }

    void Update()
    {
        // Move up if angle is > -90 and move down if angle is < 90
        if (Input.GetKey(KeyCode.S) && rotationAngle > -maximalAngle)
        {
            Move(-rotationSpeed);
        }
        else if (Input.GetKey(KeyCode.W) && rotationAngle < maximalAngle)
        {
            Move(rotationSpeed);
        }
    }

    void Move(float degree)
    {
        rotationAngle += degree;

        // Rotate around center of circle
        transform.RotateAround(arcCenter.transform.position, Vector3.forward, degree);

        // Do not turn player around own axis
        transform.rotation = originalRotation;
    }
}
