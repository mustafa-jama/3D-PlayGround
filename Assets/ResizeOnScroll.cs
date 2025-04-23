using UnityEngine;

public class ResizeOnScroll : MonoBehaviour
{
    public float resizeSpeed = 0.1f;
    public float minSize = 0.5f;
    public float maxSize = 3f;

    void Update()
    {
        // Only allow scaling if this object is the selected one
        if (ObjectSelector.SelectedObject == gameObject)
        {
            float scroll = Input.GetAxis("Mouse ScrollWheel");

            if (scroll != 0)
            {
                float newSize = Mathf.Clamp(transform.localScale.x + scroll * resizeSpeed, minSize, maxSize);
                float currentHeight = transform.localScale.y;
                float heightDifference = (newSize - currentHeight) / 2;

                transform.localScale = new Vector3(newSize, newSize, newSize);
                transform.position = new Vector3(transform.position.x, transform.position.y + heightDifference, transform.position.z);
            }
        }
    }
}
