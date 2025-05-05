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
                transform.localScale += Vector3.one * sizeChangeAmount;
                break;

            case ModeManager.Mode.SizeDown:
                transform.localScale -= Vector3.one * sizeChangeAmount;
                // Prevent negative scale
                if (transform.localScale.x < 0.1f)
                {
                    transform.localScale = Vector3.one * 0.1f;
                }
                break;

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


// using UnityEngine;

// public class ShapeClickHandler : MonoBehaviour
// {
//     public SceneManager sceneManager;
//     private Renderer rend;
//     private Color originalColor;
//     private Color selectedColor = new Color32(255, 255, 0, 255); // Yellow for selected objects

//     private void Start()
//     {
//         rend = GetComponent<Renderer>();
//         if (rend != null)
//         {
//             originalColor = rend.material.color;
//         }
//     }

//     private void OnMouseDown()
//     {
//         if (sceneManager != null)
//         {
//             // Deselect all other objects
//             GameObject[] objects = GameObject.FindGameObjectsWithTag("Selectable");
//             foreach (GameObject obj in objects)
//             {
//                 var handler = obj.GetComponent<ShapeClickHandler>();
//                 if (handler != null && handler != this)
//                 {
//                     handler.Deselect();
//                 }
//             }

//             // Select this object
//             Select();
//             sceneManager.SetSelectedObject(gameObject);
//         }
//     }

//     public void Select()
//     {
//         if (rend != null)
//         {
//             rend.material.color = selectedColor;
//         }
//     }

//     public void Deselect()
//     {
//         if (rend != null)
//         {
//             rend.material.color = originalColor;
//         }
//     }
// } 