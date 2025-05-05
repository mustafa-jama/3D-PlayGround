using UnityEngine;
using UnityEngine.UI;

public class ColorTextureSelectorUI : MonoBehaviour
{
    public Button previewButton;
    public Image previewImage;
    public GameObject selectorPanel;
    public Button colorButton;
    public Button[] textureButtons;
    public Image[] textureImages;
    public ColorPicker colorPicker; // Assign this in the Inspector

    private void Start()
    {
        if (previewButton != null)
        {
            previewButton.onClick.AddListener(OpenSelector);
        }

        if (colorButton != null)
        {
            colorButton.onClick.AddListener(OpenColorPicker);
            Image colorButtonImage = colorButton.transform.GetChild(0).GetComponent<Image>();
            if (colorButtonImage != null)
            {
                colorButtonImage.color = ColorTextureSelector.Instance.SelectedColor;
            }
        }

        for (int i = 0; i < textureButtons.Length; i++)
        {
            int index = i;
            if (textureButtons[i] != null)
            {
                textureButtons[i].onClick.AddListener(() => SelectTexture(index));
            }
        }

        UpdatePreview();
    }

    private void OpenSelector()
    {
        if (selectorPanel != null)
        {
            selectorPanel.SetActive(true);
        }
    }

    private void OpenColorPicker()
    {
        if (colorPicker != null)
        {
            colorPicker.gameObject.SetActive(true);
            colorPicker.SetColor(ColorTextureSelector.Instance.SelectedColor);
            colorPicker.OnColorSelected += OnColorSelected;
        }
    }

    private void OnColorSelected(Color color)
    {
        ColorTextureSelector.Instance.SetColor(color);
        UpdatePreview();
        if (colorButton != null)
        {
            Image colorButtonImage = colorButton.transform.GetChild(0).GetComponent<Image>();
            if (colorButtonImage != null)
            {
                colorButtonImage.color = color;
            }
        }
        CloseSelector();
        if (colorPicker != null)
        {
            colorPicker.OnColorSelected -= OnColorSelected;
            colorPicker.gameObject.SetActive(false);
        }
    }

    private void SelectTexture(int index)
    {
        if (index >= 0 && index < textureImages.Length)
        {
            if (textureImages[index].sprite == null)
            {
                Debug.LogError("Texture sprite is not assigned for index: " + index);
                return;
            }
            Texture2D texture = textureImages[index].sprite.texture;
            ColorTextureSelector.Instance.SetTexture(texture);
            UpdatePreview();
            CloseSelector();
        }
    }

    private void UpdatePreview()
    {
        if (previewImage != null)
        {
            if (ColorTextureSelector.Instance.IsColorSelected)
            {
                previewImage.sprite = null;
                previewImage.color = ColorTextureSelector.Instance.SelectedColor;
            }
            else if (ColorTextureSelector.Instance.SelectedTexture != null)
            {
                previewImage.sprite = Sprite.Create(ColorTextureSelector.Instance.SelectedTexture, new Rect(0, 0, ColorTextureSelector.Instance.SelectedTexture.width, ColorTextureSelector.Instance.SelectedTexture.height), new Vector2(0.5f, 0.5f));
                previewImage.color = Color.white;
            }
        }
    }

    private void CloseSelector()
    {
        if (selectorPanel != null)
        {
            selectorPanel.SetActive(false);
        }
    }
} 