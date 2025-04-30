using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class FieldOutline : MonoBehaviour
{
    public float width = 10f;
    public float height = 10f;
    public float y = 0f;

    private LineRenderer lineRenderer;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 5;
        lineRenderer.loop = true;
        lineRenderer.useWorldSpace = true;
        lineRenderer.widthMultiplier = 0.1f;

        Vector3[] corners = new Vector3[5];
        corners[0] = new Vector3(-width / 2, y, -height / 2);
        corners[1] = new Vector3(-width / 2, y, height / 2);
        corners[2] = new Vector3(width / 2, y, height / 2);
        corners[3] = new Vector3(width / 2, y, -height / 2);
        corners[4] = corners[0]; // close the loop

        lineRenderer.SetPositions(corners);
    }
}

