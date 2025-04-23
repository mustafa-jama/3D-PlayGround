using UnityEngine;

public class ShowCubeController : MonoBehaviour
{
    public GameObject cubePrefab;
    public Transform spawnPoint;

    // Default color based on your screenshot (B6BDE2)
    private Color defaultColor = new Color32(182, 189, 226, 255);

    public void ShowCube()
    {
        if (cubePrefab != null)
        {
            Vector3 spawnPosition = spawnPoint != null ? spawnPoint.position : Vector3.zero;

            GameObject newCube = Instantiate(cubePrefab, spawnPosition, Quaternion.identity);
            newCube.tag = "Selectable";

            Renderer rend = newCube.GetComponent<Renderer>();
            if (rend != null)
            {
                rend.material.color = defaultColor;
            }
        }
    }
}
