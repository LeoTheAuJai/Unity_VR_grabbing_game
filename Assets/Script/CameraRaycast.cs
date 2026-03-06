using UnityEngine;

public class CameraRaycast : MonoBehaviour
{
    public Camera mainCamera; // Reference to the camera
    public float maxDistance = 100f; // Maximum distance for the raycast

    void Update()
    {
        // Check if the left mouse button is clicked
        if (Input.GetMouseButtonDown(0))
        {
            
            // Create a ray from the center of the camera's viewport
            Ray ray = mainCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
            RaycastHit hit;

            // Perform the raycast
            if (Physics.Raycast(ray, out hit, maxDistance))
            {
                // Check if the ray hit a 3D object
                if (hit.collider != null)
                {
                    //Debug.Log("Clicked on: " + hit.collider.name);

                    // Trigger an event or call a method on the object
                    hit.collider.SendMessage("OnClick", SendMessageOptions.DontRequireReceiver);
                }
            }
        }
    }
}