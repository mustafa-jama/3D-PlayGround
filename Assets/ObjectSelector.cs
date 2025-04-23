using UnityEngine;

public class ObjectSelector : MonoBehaviour
{
    public static GameObject SelectedObject; // ← Add this line

    private Color originalColor;

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Left-click
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                GameObject hitObject = hit.collider.gameObject;

                if (hitObject.CompareTag("Selectable"))
                {
                    if (SelectedObject != null)
                    {
                        var prevRenderer = SelectedObject.GetComponent<Renderer>();
                        if (prevRenderer != null)
                            prevRenderer.material.color = originalColor;
                    }

                    SelectedObject = hitObject;
                    var renderer = SelectedObject.GetComponent<Renderer>();
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
