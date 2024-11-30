using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateImage : MonoBehaviour
{
    public float rotationSpeed = 100f; // Rotation speed in degrees per second

    void Update()
    {
        // Rotate the image around the Z axis to achieve a "flat" rotation
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
    }
}
