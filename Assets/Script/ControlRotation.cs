using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlRotation : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        // Get the current rotation
        Quaternion currentRotation = transform.rotation;

        // Create a new rotation with the y component set to 0
        Quaternion newRotation = Quaternion.Euler(0, currentRotation.eulerAngles.y, currentRotation.eulerAngles.z);

        // Apply the new rotation
        transform.rotation = newRotation;
    }
}