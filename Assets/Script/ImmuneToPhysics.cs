using UnityEngine;

public class ImmuneToPhysics : MonoBehaviour
{
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = true;
        rb.isKinematic = false;
        rb.mass = 1000f;       // Too heavy to push
        rb.drag = 10f;         // Quickly resists motion
        rb.angularDrag = 10f;  // Prevents spinning
        rb.constraints = RigidbodyConstraints.FreezeRotation; // No rotation
    }

    // Optional: Ignore collisions with specific objects
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Physics.IgnoreCollision(collision.collider, GetComponent<Collider>());
        }
    }
}