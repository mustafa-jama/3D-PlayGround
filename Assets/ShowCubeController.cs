using UnityEngine;

public class ShowCubeController : MonoBehaviour
{
    public GameObject cubePrefab; // Reference to the Cube Prefab
    public Transform spawnPoint; // Optional spawn point (can be empty)

    // This method is public, so Unity can detect it in the dropdown
    public void ShowCube()
    {
        if (cubePrefab != null)
        {
            // Determine the spawn position (use spawnPoint if provided, otherwise default to (0, 0, 0))
            Vector3 spawnPosition = spawnPoint != null ? spawnPoint.position : Vector3.zero;

            // Instantiate the cubePrefab at the spawn position
            GameObject newCube = Instantiate(cubePrefab, spawnPosition, Quaternion.identity);

            // Tag it as selectable
            newCube.tag = "Selectable";
        }
    }
}
