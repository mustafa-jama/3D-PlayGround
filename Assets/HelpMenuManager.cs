using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HelpMenuManager : MonoBehaviour
{
    public static HelpMenuManager Instance { get; private set; }

    public GameObject helpPanel;
    public Button helpButton;
    public Button closeButton;

    private bool isHelpMenuOpen = false;

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

    private void Start()
    {
        if (helpButton != null)
        {
            helpButton.onClick.AddListener(ToggleHelpMenu);
        }

        if (closeButton != null)
        {
            closeButton.onClick.AddListener(CloseHelpMenu);
        }

        if (helpPanel != null)
        {
            helpPanel.SetActive(false);
        }
    }

    public void ToggleHelpMenu()
    {
        isHelpMenuOpen = !isHelpMenuOpen;
        if (helpPanel != null)
        {
            helpPanel.SetActive(isHelpMenuOpen);
        }
    }

    public void CloseHelpMenu()
    {
        isHelpMenuOpen = false;
        if (helpPanel != null)
        {
            helpPanel.SetActive(false);
        }
    }
} 