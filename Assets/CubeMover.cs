using UnityEngine;

public class CubeMover : MonoBehaviour
{
    private Vector3 offset; // Offset between cube and mouse
    private Camera mainCamera; // Main camera reference
    private bool isDragging = false; // Dragging state
    public float planeWidth = 10f; // Width of the plane
    public float planeHeight = 10f; // Height of the plane
    private float planeY = 0f; // The Y position of the plane

    void Start()
    {
        mainCamera = Camera.main;
        planeY = transform.position.y; // Assume the cube starts on the plane
    }

    void OnMouseDown()
    {
        // Calculate the offset between the cube's position and the mouse world position
        offset = transform.position - GetMouseWorldPosition();
        isDragging = true;
    }

    void OnMouseDrag()
    {
        if (isDragging)
        {
            // Get the target position based on the mouse position
            Vector3 targetPosition = GetMouseWorldPosition() + offset;

            // Clamp the cube's position to stay within the bounds of the plane
            targetPosition.x = Mathf.Clamp(targetPosition.x, -planeWidth / 2, planeWidth / 2);
            targetPosition.z = Mathf.Clamp(targetPosition.z, -planeHeight / 2, planeHeight / 2);

            // Keep the cube at the plane's Y position
            targetPosition.y = planeY;

            // Update the cube's position
            transform.position = targetPosition;
        }
    }

    void OnMouseUp()
    {
        isDragging = false; // Stop dragging
    }

    private Vector3 GetMouseWorldPosition()
    {
         Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        Plane plane = new Plane(Vector3.up, new Vector3(0, planeY, 0)); // horizontal plane at Y = planeY

        float distance;
        if (plane.Raycast(ray, out distance))
        {
            return ray.GetPoint(distance); // point on the plane where the ray hits
        }

        return Vector3.zero; // fallback (shouldn't happen in normal use)
    }
}
