using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePlatform : MonoBehaviour
{
    public float rotationSpeed = 10f;

    private Vector3 originalPosition;
    private Quaternion originalRotation;
    private float rotationAngle = 0f;
    private bool rotatingClockwise = true;

    // Start is called before the first frame update
    void Start()
    {
        originalPosition = transform.position;
        originalRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the platform has rotated 180 degrees
        if (rotationAngle >= 180f)
        {
            rotatingClockwise = !rotatingClockwise;
            rotationAngle = 0f;
        }

        // Calculate the angle of rotation
        rotationAngle += rotationSpeed * Time.deltaTime;

        // Rotate the platform
        if (rotatingClockwise)
        {
            transform.RotateAround(originalPosition, Vector3.up, rotationSpeed * Time.deltaTime);
        }
        else
        {
            transform.RotateAround(originalPosition, Vector3.down, rotationSpeed * Time.deltaTime);
        }

        // Return the platform to its original position and rotation
        if (rotationAngle >= 180f)
        {
            transform.position = originalPosition;
            transform.rotation = originalRotation;
        }
    }
}
