using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    [Header("Position")]
    [SerializeField] Vector2 startPoint;
    [SerializeField] Vector2 endPoint;
    [SerializeField] float shiftStartPointX; 
    
    [Header("Speed")]
    [SerializeField] float noteSpeed = 5;

    void Awake()
    {
        startPoint.x -= shiftStartPointX;
        transform.position = startPoint;
    }

    void Update()
    {
        // Move between two points
        transform.position = Vector3.MoveTowards(transform.position, endPoint, noteSpeed * Time.deltaTime);

        // If Note reaches endPoint
        if (transform.position == new Vector3(endPoint.x, endPoint.y, 0))
        {
            
        }
    }
}
