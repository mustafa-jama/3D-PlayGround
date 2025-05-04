using UnityEngine;

public class BuildButtonHandler : MonoBehaviour
{
    public GameObject shapePanel;

    public void ToggleShapePanel()
    {
        shapePanel.SetActive(!shapePanel.activeSelf);
    }
}
