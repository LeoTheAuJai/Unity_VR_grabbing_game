using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public float gravity = -9.81f; // Gravity for realistic falling
    public float jumpHeight = 2f; // Height of the jump
    public float interactionDistance = 5f; // Maximum distance for interacting with objects

    private CharacterController controller; // Reference to the CharacterController component
    private Vector3 velocity; // Tracks player velocity
    private bool isGrounded; // Checks if the player is on the ground

    public Image crosshair; // Reference to the crosshair UI image
    public Color defaultColor = Color.white; // Default crosshair color
    public Color highlightColor = Color.red; // Crosshair color when pointing at a clickable object
    public float moveSpeed = 5f; // Speed of player movement
    public XROrigin xrOrigin; // Reference to the XR Origin
    private CharacterController characterController; // Reference to the CharacterController component

    void Start()
    {
        // Get the CharacterController component
        characterController = GetComponent<CharacterController>();

        // Ensure the XR Origin is assigned
        if (xrOrigin == null)
        {
            Debug.LogError("XR Origin is not assigned to the PlayerMovement script.");
        }

        // Lock and hide the cursor initially
        LockCursor();
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ToggleCursorLock();
        }
    }

    void Update()
    {
        /*
        // Get movement input from the player
        float moveX = Input.GetAxis("Horizontal"); // A (-1) and D (1)
        float moveZ = Input.GetAxis("Vertical"); // S (-1) and W (1)

        // Calculate movement direction relative to the XR Origin's rotation
        Vector3 moveDirection = xrOrigin.transform.forward * moveZ + xrOrigin.transform.right * moveX;
        moveDirection.y = 0; // Ensure no vertical movement

        // Normalize the movement vector to prevent faster diagonal movement
        moveDirection.Normalize();

        // Apply movement to the CharacterController
        characterController.Move(moveDirection * moveSpeed * Time.deltaTime);

        // Re-lock the cursor if it's unlocked (e.g., after clicking outside the game window)
        if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
        {
            LockCursor();
        }*/
        CheckForClickableObjects();
    }

    void OnApplicationFocus(bool hasFocus)
    {
        // Re-lock the cursor when the game window regains focus
        if (hasFocus)
        {
            LockCursor();
        }
    }

    void LockCursor()
    {
        // Lock the cursor to the center of the screen and hide it
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    void ToggleCursorLock()
    {
        if (Cursor.lockState == CursorLockMode.Locked)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            LockCursor();
        }
    }
    void CheckForClickableObjects()
    {
        // Create a ray from the center of the camera
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        // Perform the raycast
        if (Physics.Raycast(ray, out hit, interactionDistance))
        {
            // Check if the object is clickable
            if (hit.collider.CompareTag("Clickable"))
            {
                // Change crosshair color to highlight
                crosshair.color = highlightColor;

                // Handle click input
                if (Input.GetMouseButtonDown(0))
                {
                    Debug.Log("Clicked on: " + hit.collider.name);
                    // Add your click logic here (e.g., interact with the object)
                }
            }
            else
            {
                // Reset crosshair color
                crosshair.color = defaultColor;
            }
        }
        else
        {
            // Reset crosshair color
            crosshair.color = defaultColor;
        }
    }
}

    
