using UnityEngine;
using UnityEngine.UI;

public class ModeButton : MonoBehaviour
{
    public ModeManager.Mode mode;
    public GameObject shapePanel;
    private Button button;
    private Image buttonImage;
    private Color activeColor = new Color(1f, 0.6f, 0.6f);
    private Color normalColor = Color.white;

    private void Start()
    {
        button = GetComponent<Button>();
        buttonImage = GetComponent<Image>();
        
        if (button != null)
        {
            button.onClick.AddListener(OnButtonClick);
        }

        if (mode == ModeManager.Mode.Build && shapePanel != null)
        {
            shapePanel.SetActive(false);
        }
    }

    private void OnButtonClick()
    {
        ModeManager.Instance.SetMode(mode);
    }

    public void UpdateAppearance(ModeManager.Mode currentMode)
    {
        if (buttonImage != null)
        {
            buttonImage.color = (currentMode == mode) ? activeColor : normalColor;
        }

        if (mode == ModeManager.Mode.Build && shapePanel != null)
        {
            shapePanel.SetActive(currentMode == ModeManager.Mode.Build);
        }
    }
} 