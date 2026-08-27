using UnityEngine;



public class NewPlayerController : MonoBehaviour
{
    public float moveSpeed = 10.0f;
    public float jumpForce = 5.0f;
    public float horizontalInput;

    [Header("Camera Settings")]
    public Vector3 cameraOffset = new Vector3(0, 5, -10);

    private Rigidbody rb;
    private bool isGrounded = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Try to get the Rigidbody attached to this GameObject
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // Get input from WASD or arrow keys
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Calculate the movement direction
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        // Move the object based on time and speed
        transform.Translate(movement * moveSpeed * Time.deltaTime, Space.World);

        // Jump when Spacebar is pressed and the player is grounded
        if (Input.GetKeyDown(KeyCode.Space) && rb != null && isGrounded)
        {
            // Adding upward force to make the object jump
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false; // Prevent jumping again until touching the ground
        }
        // Restart position if player falls off map
        if (transform.position.y < -7f)
        {
            transform.position = new Vector3(1f, -0.25f, 1f);

            // If the object has a rigidbody, reset its velocity so it stops falling
            Rigidbody rb = GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.linearVelocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
            }
        }
    }

    void LateUpdate()
    {
        // Finds the Main Camera in the scene and updates its position to follow the player
        if (Camera.main != null)
        {
            Camera.main.transform.position = transform.position + cameraOffset;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Reset the grounded state when colliding with an object (assumed to be the ground)
        // You can also add `&& collision.gameObject.CompareTag("Ground")` if you set up Tags
        isGrounded = true;
    }
}
