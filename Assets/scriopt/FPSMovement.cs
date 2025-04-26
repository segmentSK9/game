using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class FPSMovement : MonoBehaviour
{
    public float walkSpeed = 3f;         // Slower walk speed for control
    public float sprintSpeed = 6f;       // Sprint speed when holding shift
    public float mouseSensitivity = 2f;  // Mouse sensitivity
    public float forwardSpeed = 2f;      // Speed while moving forward (middle mouse)
    public Transform playerCamera;       // Reference to player's camera
    public KeyCode toggleMoveKey = KeyCode.R;  // Button to toggle forward movement

    private float speed;
    private bool isMovingForward = false;  // Track if we're moving forward
    private CharacterController controller;
    private float verticalRotation = 0f;
    private float horizontalRotation = 0f;  // Track horizontal rotation

    // Rotation limits
    public float minVerticalRotation = -80f; // Min vertical angle
    public float maxVerticalRotation = 80f;  // Max vertical angle
    public float minHorizontalRotation = -60f; // Min horizontal angle
    public float maxHorizontalRotation = 60f;  // Max horizontal angle

    void Start()
    {
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        // === Mouse Look ===
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        // Horizontal Rotation (around Y-axis)
        horizontalRotation += mouseX;
        horizontalRotation = Mathf.Clamp(horizontalRotation, minHorizontalRotation, maxHorizontalRotation);
        transform.rotation = Quaternion.Euler(0f, horizontalRotation, 0f);  // Rotate player object around Y-axis

        // Vertical Rotation (around X-axis)
        verticalRotation -= mouseY;
        verticalRotation = Mathf.Clamp(verticalRotation, minVerticalRotation, maxVerticalRotation);
        playerCamera.localRotation = Quaternion.Euler(verticalRotation, 0f, 0f); // Apply vertical rotation to camera

        // === Movement ===
        speed = Input.GetKey(KeyCode.LeftShift) ? sprintSpeed : walkSpeed;

        // Toggle forward movement using the 'R' key
        if (Input.GetKeyDown(toggleMoveKey))
        {
            isMovingForward = !isMovingForward;  // Toggle the forward movement
        }

        // If middle mouse is pressed or forward toggle is active, move forward
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        // Apply forward movement logic only when toggled on
        if (isMovingForward || Input.GetMouseButton(2))  // Middle mouse button to keep moving forward
        {
            moveZ = forwardSpeed;  // Move forward with the specified speed
        }

        // Apply movement (WASD)
        Vector3 move = transform.right * moveX + transform.forward * moveZ;
        controller.Move(move * speed * Time.deltaTime);

        // Add a safety stop (optional) to reduce speed gradually when toggling off
        if (!isMovingForward && moveZ != 0)
        {
            moveZ = 0;  // Stop forward movement if toggle is off
        }
    }
}
