using UnityEngine;

public class CameraMouseLook : MonoBehaviour
{
    public float mouseSensitivity = 100f; // Sensitivity of mouse movement

    private float xRotation = 0f; // Tracks vertical rotation

    void Start()
    {
        // Lock the cursor to the center of the screen and make it invisible
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // Get mouse input
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Rotate the camera vertically
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // Limit vertical rotation to avoid flipping

        // Apply vertical rotation to the camera
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // Rotate the camera horizontally (if there's no parent)
        if (transform.parent != null)
        {
            // Rotate the parent object horizontally
            transform.parent.Rotate(Vector3.up * mouseX);
        }
        else
        {
            // Rotate the camera itself horizontally
            transform.Rotate(Vector3.up * mouseX);
        }
    }
}