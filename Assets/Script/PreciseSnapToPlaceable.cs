using UnityEngine;
using System.Collections;

public class SimpleCenterSnap : MonoBehaviour
{
    [Header("Snap Settings")]
    [SerializeField] private string placeableTag = "placeable";
    [SerializeField] private float yOffset = 0.1f;
    private Vector3 initialPosition;
    private Quaternion initialRotation;
    public GameObject Go_origin;

    private float delayTime = 5f; // Delay duration in seconds
    private float timer = 0f; // Timer to track elapsed time
    private bool isDelayActive = false; // Control whether waiting
    private void Start()
    {
        initialPosition = transform.position;
        initialRotation = transform.rotation;
    }

    void Update()
    {
        if (transform.position.z > 5 || transform.position.z < -20 || transform.position.x < -11 || transform.position.x > 9 || transform.position.y < -2)
        {
            transform.position = initialPosition;
            transform.rotation = initialRotation;
        }

        GotoOrigin();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(placeableTag)&& !Go_origin.activeSelf)
        {
            // Check if collision happened from above (surface normal points up)
            if (Vector3.Dot(collision.contacts[0].normal, Vector3.up) > 0.5f)
            {
                SnapToCenter(collision.transform);
            }
        }
    }

    private void SnapToCenter(Transform placeableTransform)
    {
        // Calculate center position
        Vector3 centerPosition = placeableTransform.position;
        centerPosition.y += yOffset;

        // Set position and rotation directly
        transform.position = centerPosition;
        transform.rotation = Quaternion.identity;
        transform.rotation = initialRotation;

        // Stop any physics movement
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }

        Debug.Log("Snapped to center of: " + placeableTransform.name);
    }

    private void OnDrawGizmosSelected()
    {
        // Visualize the yOffset
        Gizmos.color = Color.cyan;
        Gizmos.DrawLine(transform.position, transform.position - Vector3.up * yOffset);
    }

    public void GotoOrigin()
    {
        if (Go_origin.activeSelf)
        {
            transform.position = initialPosition;
            transform.rotation = initialRotation;
        }
    }
}