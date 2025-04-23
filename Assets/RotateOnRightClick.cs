using UnityEngine;

public class RotateSelectedObject : MonoBehaviour
{
    public float rotationSpeed = 100f;

    void Update()
    {
        // Only act if there is a selected object
        if (ObjectSelector.SelectedObject != null)
        {
            if (Input.GetKey(KeyCode.Q))
            {
                ObjectSelector.SelectedObject.transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.E))
            {
                ObjectSelector.SelectedObject.transform.Rotate(Vector3.up, -rotationSpeed * Time.deltaTime);
            }
        }
    }
}
