using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class SceneManager : MonoBehaviour
{
    public Button trashButton;
    public Button resetButton;
    public GameObject confirmationDialog;
    public Button confirmResetButton;
    public Button cancelResetButton;
    public TextMeshProUGUI confirmationText;
    public CameraController cameraController;

    private GameObject selectedObject;

    private void Start()
    {
        // Initialize UI elements
        if (trashButton != null)
        {
            trashButton.onClick.AddListener(DeleteSelectedObject);
            trashButton.interactable = false; // Initially disabled
        }

        if (resetButton != null)
        {
            resetButton.onClick.AddListener(ShowResetConfirmation);
        }

        if (confirmationDialog != null)
        {
            confirmationDialog.SetActive(false);
        }

        if (confirmResetButton != null)
        {
            confirmResetButton.onClick.AddListener(ResetScene);
        }

        if (cancelResetButton != null)
        {
            cancelResetButton.onClick.AddListener(HideResetConfirmation);
        }

        // Find camera controller if not assigned
        if (cameraController == null)
        {
            cameraController = Camera.main.GetComponent<CameraController>();
        }
    }

    public void SetSelectedObject(GameObject obj)
    {
        selectedObject = obj;
        if (trashButton != null)
        {
            trashButton.interactable = (obj != null);
        }
    }

    private void DeleteSelectedObject()
    {
        if (selectedObject != null)
        {
            Destroy(selectedObject);
            selectedObject = null;
            if (trashButton != null)
            {
                trashButton.interactable = false;
            }
        }
    }

    private void ShowResetConfirmation()
    {
        if (confirmationDialog != null)
        {
            confirmationDialog.SetActive(true);
        }
    }

    private void HideResetConfirmation()
    {
        if (confirmationDialog != null)
        {
            confirmationDialog.SetActive(false);
        }
    }

    private void ResetScene()
    {
        // Find all objects with the "Selectable" tag
        GameObject[] objects = GameObject.FindGameObjectsWithTag("Selectable");
        foreach (GameObject obj in objects)
        {
            Destroy(obj);
        }

        // Reset camera if available
        if (cameraController != null)
        {
            cameraController.ResetCamera();
        }

        // Clear selection
        selectedObject = null;
        if (trashButton != null)
        {
            trashButton.interactable = false;
        }

        // Hide confirmation dialog
        HideResetConfirmation();
    }
} 