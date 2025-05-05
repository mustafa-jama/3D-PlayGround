using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float rotateSpeed = 3f;
    public float zoomSpeed = 10f;
    public float minZoom = 5f;
    public float maxZoom = 50f;

    private Vector3 lastMousePosition;
    private Vector3 initialPosition;
    private Quaternion initialRotation;

    void Start()
    {
        // Store initial camera position and rotation
        initialPosition = transform.position;
        initialRotation = transform.rotation;
    }

    void Update()
    {
        HandleMovement();
        HandleRotation();
        HandleZoom();
    }

    void HandleMovement()
    {
        float moveX = Input.GetAxis("Horizontal"); // A/D or Left/Right
        float moveZ = Input.GetAxis("Vertical");   // W/S or Up/Down

        Vector3 move = transform.right * moveX + transform.forward * moveZ;
        transform.position += move * moveSpeed * Time.deltaTime;
    }

    void HandleRotation()
    {
        if (Input.GetMouseButton(1)) // Right mouse button held
        {
            float mouseX = Input.GetAxis("Mouse X");
            float mouseY = Input.GetAxis("Mouse Y");

            Vector3 rotation = transform.eulerAngles;
            rotation.y += mouseX * rotateSpeed;
            rotation.x -= mouseY * rotateSpeed;

            transform.eulerAngles = rotation;
        }
    }

    void HandleZoom()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        Vector3 direction = transform.forward;

        transform.position += direction * scroll * zoomSpeed;
        float distance = Vector3.Distance(transform.position, Vector3.zero); // zoom centered on world origin

        if (distance < minZoom)
            transform.position = Vector3.zero + direction * minZoom;

        if (distance > maxZoom)
            transform.position = Vector3.zero + direction * maxZoom;
    }

    public void ResetCamera()
    {
        transform.position = initialPosition;
        transform.rotation = initialRotation;
    }
}
