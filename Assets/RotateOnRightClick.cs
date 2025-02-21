using UnityEngine;

public class RotateOnRightClick : MonoBehaviour
{
    public float rotationSpeed = 300f; // Speed of rotation

    void Update()
    {
        // Check if the right mouse button is held down
        if (Input.GetMouseButton(1)) // Right mouse button (0 = left, 1 = right, 2 = middle)
        {
            // Get mouse movement
            float mouseX = Input.GetAxis("Mouse X"); // Horizontal mouse movement
            float mouseY = Input.GetAxis("Mouse Y"); // Vertical mouse movement

            // Rotate the cube based on mouse movement
            transform.Rotate(Vector3.up, -mouseX * rotationSpeed * Time.deltaTime, Space.World); // Rotate around Y-axis
            transform.Rotate(Vector3.right, mouseY * rotationSpeed * Time.deltaTime, Space.World); // Rotate around X-axis
        }
    }
}
