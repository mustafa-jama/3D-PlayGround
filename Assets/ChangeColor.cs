using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    private Renderer cubeRenderer; // Reference to the cube's renderer
    public Color[] colors; // Array of colors to cycle through
    private int currentColorIndex = 0; // Track the current color index

    void Start()
    {
        // Get the Renderer component of the cube
        cubeRenderer = GetComponent<Renderer>();

        // Set the initial color if the array is not empty
        if (colors.Length > 0)
        {
            cubeRenderer.material.color = colors[currentColorIndex];
        }
    }

    void Update()
    {
        // Change color on key press
        if (Input.GetKeyDown(KeyCode.C)) // Press "C" to change color
        {
            ChangeToNextColor();
        }
    }

    void ChangeToNextColor()
    {
        // Increment the color index and loop back if necessary
        currentColorIndex = (currentColorIndex + 1) % colors.Length;

        // Apply the new color
        cubeRenderer.material.color = colors[currentColorIndex];
    }
}
