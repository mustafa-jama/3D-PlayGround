using UnityEngine;

public class ShapeClickHandler : MonoBehaviour
{
    void OnMouseDown()
    {
        if (DeleteManager.IsDeleteMode)
        {
            Destroy(gameObject);
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