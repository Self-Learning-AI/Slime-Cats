// Written by Igor Barbosa

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floater : MonoBehaviour
{
    // Float & rotation attributes
    public float moveDistance = 0.1f;
    public float rotationDistance = 0.08f;
    public float floatSpeed = 0.2f;
    public float rotationSpeed = 0.1f;

    // Position vectors
    Vector3 originalPosition = new Vector3();
    Vector3 newPosition = new Vector3();

    // Rotation position
    Quaternion originalRotation;
    Quaternion newRotation;

    // Use this for initialization
    void Start()
    {
        // Get original position of the object
        originalPosition = transform.position;
        originalRotation = transform.rotation;
    }

    void Update()
    {
        
        //transform.Rotate(new Vector3(0.0f, Time.deltaTime * rotationSpeed, 0.0f), Space.World);

        // Float up and down on the Y-Axis
        // Uses Mathf.Sin to create momentum effect
        newPosition = originalPosition;
        newPosition.y += Mathf.Sin(Time.fixedTime * Mathf.PI * floatSpeed) * moveDistance;

        // Spin left and right on the Y-Axis
        // Uses Mathf.Sin to create momentum effect
        newRotation = originalRotation;
        newRotation.y += Mathf.Sin(Time.fixedTime * Mathf.PI * rotationSpeed) * rotationDistance;

        transform.position = newPosition;
        transform.rotation = newRotation;
    }
}
