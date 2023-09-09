using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    internal static PlayerMovement instance;

    Vector3 originalPosition;
    Quaternion originalRotation;

    bool resettingPosition;

    [Header("Move on Arc")]
    [SerializeField] GameObject arcCenter;
    [SerializeField] float rotationSpeed = 0.25f;
    [SerializeField] float maximalAngle = 60;
    float rotationAngle;

    [Header("Move Freely")]
    [SerializeField] float movementSpeed = 5f;
    public bool freeMovement;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        originalPosition = transform.position;
        originalRotation = transform.rotation;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ToggleFreeMovement();
        }

        if (!resettingPosition)
        {
            if (!freeMovement)
            {
                // Move up if angle is > -90 and move down if angle is < 90
                if (Input.GetKey(KeyCode.S) && rotationAngle > -maximalAngle)
                {
                    MoveArc(-rotationSpeed);
                }
                else if (Input.GetKey(KeyCode.W) && rotationAngle < maximalAngle)
                {
                    MoveArc(rotationSpeed);
                }
            }
            else
            {
                MoveFreely();
            }
        }
    }

    void MoveArc(float degree)
    {
        rotationAngle += degree;

        // Rotate around center of circle
        transform.RotateAround(arcCenter.transform.position, Vector3.forward, degree);

        // Do not turn player around own axis
        transform.rotation = originalRotation;
    }

    void MoveFreely()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        Vector3 movement = new Vector3(horizontalInput, verticalInput);

        transform.Translate(movementSpeed * Time.deltaTime * movement.normalized, Space.World);
    }

    void ToggleFreeMovement()
    {
        if (freeMovement)
        {
            freeMovement = false;
            rotationAngle = 0f;
            StartCoroutine(ResetPosition());
        }
        else
        {
            freeMovement = true;
        }
    }

    IEnumerator ResetPosition()
    {
        resettingPosition = true;

        while (transform.position != originalPosition)
        {
            transform.position = Vector3.MoveTowards(transform.position, originalPosition, movementSpeed * Time.deltaTime);
            yield return null;
        }

        resettingPosition = false;
    }
}
