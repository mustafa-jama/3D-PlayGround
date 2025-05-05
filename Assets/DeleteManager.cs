using UnityEngine;
using UnityEngine.UI;

public class DeleteManager : MonoBehaviour
{
    public static bool IsDeleteMode = false;

    public Button deleteButton;
    public GameObject statusText;

    private Color activeColor = new Color(1f, 0.6f, 0.6f);
    private Color normalColor = Color.white;

    public void ToggleDeleteMode()
    {
        IsDeleteMode = !IsDeleteMode;

        // Visual feedback
        if (deleteButton != null)
        {
            ColorBlock cb = deleteButton.colors;
            cb.normalColor = IsDeleteMode ? activeColor : normalColor;
            deleteButton.colors = cb;
        }

        if (statusText != null)
        {
            statusText.SetActive(IsDeleteMode);
        }

        Debug.Log("Delete mode is now: " + IsDeleteMode);
    }
}