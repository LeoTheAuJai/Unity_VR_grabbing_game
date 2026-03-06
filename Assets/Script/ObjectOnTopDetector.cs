using UnityEngine;

public class ObjectOnTopDetector : MonoBehaviour
{
    [Header("Detection Settings")]
    [SerializeField] private float detectionHeight = 1f;
    [SerializeField] private float checkInterval = 0.1f;

    private float nextCheckTime;
    private GameObject currentTopObject;

    private void Update()
    {
        /*
        if (Time.time < nextCheckTime) return;
        nextCheckTime = Time.time + checkInterval;*/

        // Cast a ray upward to detect objects
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.up, out hit, detectionHeight))
        {
            if (hit.collider.gameObject != currentTopObject)
            {
                currentTopObject = hit.collider.gameObject;
                Debug.Log("Object detected on top: " + currentTopObject.name, currentTopObject);
            }
        }
        else if (currentTopObject != null)
        {
            Debug.Log("No object detected on top");
            currentTopObject = null;
        }
    }

    // Visualize the detection ray in editor
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.up * detectionHeight);
    }
}