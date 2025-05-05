using UnityEngine;
using UnityEngine.SceneManagement;

public class ShapeSpawnerController : MonoBehaviour
{
    public GameObject cubePrefab;
    public GameObject spherePrefab;
    public GameObject cylinderPrefab;
    public Transform spawnPoint;
    public SceneManager sceneManager;

    // Default color based on your screenshot (B6BDE2)
    private Color defaultColor = new Color32(182, 189, 226, 255);

    public void SpawnCube()
    {
        SpawnShape(cubePrefab);
    }

    public void SpawnSphere()
    {
        SpawnShape(spherePrefab);
    }

    public void SpawnCylinder()
    {
        SpawnShape(cylinderPrefab);
    }

    private void SpawnShape(GameObject prefab)
    {
        if (prefab != null)
        {
            Vector3 spawnPosition = spawnPoint != null ? spawnPoint.position : Vector3.zero;

            // Create the shape
            GameObject newShape = Instantiate(prefab, spawnPosition, Quaternion.identity);
            newShape.tag = "Selectable";

            // Add click handler to the shape
            var clickHandler = newShape.AddComponent<ShapeClickHandler>();
            //clickHandler.sceneManager = sceneManager;

            // Set the color
            Renderer rend = newShape.GetComponent<Renderer>();
            if (rend != null)
            {
                rend.material.color = defaultColor;
            }

            // Adjust position to be fully above ground
            Collider collider = newShape.GetComponent<Collider>();
            if (collider != null)
            {
                // Get the bounds of the collider
                Bounds bounds = collider.bounds;
                // Move the object up by half its height
                float heightOffset = bounds.extents.y;
                newShape.transform.position += Vector3.up * heightOffset;
            }
        }
    }
}
