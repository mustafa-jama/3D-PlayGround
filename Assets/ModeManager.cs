using UnityEngine;
using UnityEngine.UI;

public class ModeManager : MonoBehaviour
{
    public static ModeManager Instance { get; private set; }

    public enum Mode
    {
        None,
        Build,
        Delete,
        SizeUp,
        SizeDown,
        Paint
    }

    private Mode currentMode = Mode.None;
    public Mode CurrentMode => currentMode;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetMode(Mode newMode)
    {
        // If clicking the same mode button, turn it off
        if (currentMode == newMode)
        {
            currentMode = Mode.None;
        }
        else
        {
            currentMode = newMode;
        }

        // Update UI to reflect the current mode
        UpdateModeUI();
    }

    private void UpdateModeUI()
    {
        // Find all mode buttons and update their appearance
        Button[] modeButtons = FindObjectsOfType<Button>();
        foreach (Button button in modeButtons)
        {
            ModeButton modeButton = button.GetComponent<ModeButton>();
            if (modeButton != null)
            {
                modeButton.UpdateAppearance(currentMode);
            }
        }
    }
} 