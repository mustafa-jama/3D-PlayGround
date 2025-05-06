using UnityEngine;

public class ShapeClickHandler : MonoBehaviour
{
    private Renderer rend;
    private Color originalColor;
    private Color paintColor = Color.yellow;
    private float sizeChangeAmount = 0.1f;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        if (rend != null)
        {
            originalColor = rend.material.color;
        }
    }

    void OnMouseDown()
    {
        if (ModeManager.Instance == null) return;

        switch (ModeManager.Instance.CurrentMode)
        {
            case ModeManager.Mode.Delete:
                Destroy(gameObject);
                break;

            case ModeManager.Mode.SizeUp:
                {
                    Vector3 oldScale = transform.localScale;
                    transform.localScale += Vector3.one * sizeChangeAmount;

                    // Adjust position to keep the bottom of the object at the same level
                    float scaleChange = transform.localScale.y - oldScale.y;
                    if (gameObject.name.ToLower().Contains("cylinder"))
                    {
                        transform.position += Vector3.up * scaleChange;
                    }
                    else
                    {
                        transform.position += Vector3.up * (scaleChange / 2);
                    }
                    break;
                }

            case ModeManager.Mode.SizeDown:
                {
                    Vector3 oldScale = transform.localScale;
                    transform.localScale -= Vector3.one * sizeChangeAmount;

                    // Prevent the object from shrinking below a minimum size
                    if (transform.localScale.x < 0.1f)
                    {
                        transform.localScale = Vector3.one * 0.1f;
                    }

                    // Adjust position to keep the bottom of the object at the same level
                    float scaleChange = transform.localScale.y - oldScale.y;
                    if (gameObject.name.ToLower().Contains("cylinder"))
                    {
                        transform.position += Vector3.up * scaleChange;
                    }
                    else
                    {
                        transform.position += Vector3.up * (scaleChange / 2);
                    }
                    break;
                }

            case ModeManager.Mode.Paint:
                if (rend != null)
                {
                    if (ColorTextureSelector.Instance != null)
                    {
                        if (ColorTextureSelector.Instance.IsColorSelected)
                        {
                            rend.material.color = ColorTextureSelector.Instance.SelectedColor;
                            rend.material.mainTexture = null;
                        }
                        else if (ColorTextureSelector.Instance.SelectedTexture != null)
                        {
                            rend.material.mainTexture = ColorTextureSelector.Instance.SelectedTexture;
                        }
                    }
                }
                break;
        }
    }
}