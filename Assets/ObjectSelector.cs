using UnityEngine;

public class ObjectSelector : MonoBehaviour
{
    private GameObject selectedObject;
    private Color originalColor;

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Left-click
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                GameObject hitObject = hit.collider.gameObject;

                // Only select if it's tagged as Selectable
                if (hitObject.CompareTag("Selectable"))
                {
                    // Deselect previous
                    if (selectedObject != null)
                    {
                        var prevRenderer = selectedObject.GetComponent<Renderer>();
                        if (prevRenderer != null)
                            prevRenderer.material.color = originalColor;
                    }

                    // Select new
                    selectedObject = hitObject;
                    var renderer = selectedObject.GetComponent<Renderer>();
                    if (renderer != null)
                    {
                        originalColor = renderer.material.color;
                        renderer.material.color = Color.yellow;
                    }
                }
            }
        }
    }
}
