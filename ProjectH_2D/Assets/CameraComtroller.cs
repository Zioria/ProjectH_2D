using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;       // Reference to the player's transform
    public Vector3 offset;         // Offset position of the camera relative to the player
    public float smoothSpeed = 0.125f;  // Speed of the camera smoothing

    void LateUpdate()
    {
        // Desired position based on target position and offset
        Vector3 desiredPosition = target.position + offset;

        // Smoothly interpolate between the camera's current position and the desired position
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // Set the camera's position
        transform.position = smoothedPosition;
    }
}
