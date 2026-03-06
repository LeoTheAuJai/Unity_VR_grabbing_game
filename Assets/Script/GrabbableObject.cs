using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.XR.Interaction.Toolkit;

public class GrabbableObject : XRGrabInteractable
{
    public float grabDistance = 5f; // Maximum distance to grab the object
    public float throwForce = 10f; // Force applied when throwing the object

    private bool isGrabbed = false; // Track if the object is currently grabbed
    private Camera mainCamera; // Reference to the main camera
    private Rigidbody rb; // Reference to the object's Rigidbody


    private Vector3 initialPosition;
    void Start()
    {
        mainCamera = Camera.main; // Get the main camera
        rb = GetComponent<Rigidbody>(); // Get the Rigidbody component
        initialPosition = transform.position;
    }

    void Update()
    {
        // Check for left-click to grab or release the object
        if (Input.GetMouseButtonDown(0)) // Left-click
        {
            if (!isGrabbed)
            {
                TryGrabObject();
            }
            else
            {
                ReleaseObject();
            }
        }

        // Move the object if it's grabbed
        if (isGrabbed)
        {
            MoveGrabbedObject();
        }
        if (transform.position.y < -10)
        {
            // Reset the position to the initial position
            transform.position = initialPosition;
        }
    }
    protected override void OnSelectEntered(XRBaseInteractor interactor)
    {
        base.OnSelectEntered(interactor);
        Debug.Log("Grabbed!");
    }
    void TryGrabObject()
    {
        // Create a ray from the mouse position
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        // Perform the raycast
        if (Physics.Raycast(ray, out hit, grabDistance))
        {
            // Check if the raycast hit this object
            if (hit.collider.gameObject == gameObject)
            {
                isGrabbed = true;
                rb.isKinematic = true; // Disable physics while grabbed
                //Debug.Log("Object grabbed");
            }
        }
    }

    void MoveGrabbedObject()
    {
        // Move the object to a point in front of the camera
        Vector3 targetPosition = mainCamera.transform.position + mainCamera.transform.forward * grabDistance;
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * 10f);
    }

    void ReleaseObject()
    {
        // Create a ray from the camera to detect the object being faced
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        // Perform the raycast
        if (Physics.Raycast(ray, out hit, grabDistance))
        {
            // Check if the hit object has the "Placeable" tag
            if (hit.collider.CompareTag("placeable"))
            {
                // Place the grabbed object on top of the placeable object
                PlaceObjectOn(hit.collider.gameObject);
            }
            else
            {
                // Throw the object if the faced object is not placeable
                ThrowObject();
            }
        }
        else
        {
            // Throw the object if no object is faced
            ThrowObject();
        }

        isGrabbed = false;
        rb.isKinematic = false; // Re-enable physics
    }

    void PlaceObjectOn(GameObject placeableObject)
    {
        // Calculate the position to place the grabbed object on top of the placeable object
        Vector3 placeableTop = placeableObject.transform.position + Vector3.up * (placeableObject.GetComponent<Collider>().bounds.extents.y);
        Vector3 grabbedObjectBottom = transform.position - Vector3.up * (GetComponent<Collider>().bounds.extents.y);

        // Move the grabbed object to the top of the placeable object
        transform.position = placeableTop + (transform.position - grabbedObjectBottom);

        //Debug.Log("Object placed on " + placeableObject.name);
    }

    void ThrowObject()
    {
        // Apply a throw force in the direction the camera is facing
        rb.velocity = mainCamera.transform.forward * throwForce;
        //Debug.Log("Object thrown");
    }
}