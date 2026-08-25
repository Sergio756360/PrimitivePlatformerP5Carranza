using UnityEngine;



public class NewPlayerController : MonoBehaviour
{
    public float moveSpeed = 10.0f;
    public float jumpForce = 5.0f;
    public float horizontalInput;

    [Header("Camera Settings")]
    public Vector3 cameraOffset = new Vector3(0, 5, -10);

    private Rigidbody rb;

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

        // Jump when Spacebar is pressed
        if (Input.GetKeyDown(KeyCode.Space) && rb != null)
        {
            // Adding upward force to make the object jump
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
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
}
