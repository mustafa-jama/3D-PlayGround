using UnityEngine;

public class ResizeOnScroll : MonoBehaviour
{
    public float resizeSpeed = 0.1f; // Speed of resizing
    public float minSize = 0.5f;    // Minimum size of the cube
    public float maxSize = 3f;      // Maximum size of the cube

    void Update()
    {
        // Get the scroll input
        float scroll = Input.GetAxis("Mouse ScrollWheel");

        if (scroll != 0)
        {
            // Calculate the new size
            float newSize = Mathf.Clamp(transform.localScale.x + scroll * resizeSpeed, minSize, maxSize);

            // Get the current height of the cube
            float currentHeight = transform.localScale.y;

            // Calculate the height difference after resizing
            float heightDifference = (newSize - currentHeight) / 2;

            // Apply the new size uniformly
            transform.localScale = new Vector3(newSize, newSize, newSize);

            // Adjust the Y position to compensate for height difference
            transform.position = new Vector3(transform.position.x, transform.position.y + heightDifference, transform.position.z);
        }
    }
}
