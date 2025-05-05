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

    if (deleteButton != null)
    {
        Image buttonImage = deleteButton.GetComponent<Image>();
        if (buttonImage != null)
        {
            buttonImage.color = IsDeleteMode ? activeColor : normalColor;
        }
    }

    if (statusText != null)
    {
        statusText.SetActive(IsDeleteMode);
    }

    Debug.Log("Delete mode is now: " + IsDeleteMode);
}

}