using UnityEngine;
using UnityEngine.UI;
using System;

public class ColorPicker : MonoBehaviour
{
    public event Action<Color> OnColorSelected;
    public Image colorPreview;
    public Slider redSlider;
    public Slider greenSlider;
    public Slider blueSlider;
    public Button confirmButton;
    public Button cancelButton;

    private Color currentColor;

    private void Start()
    {
        if (redSlider != null)
        {
            redSlider.onValueChanged.AddListener(OnColorChanged);
        }
        if (greenSlider != null)
        {
            greenSlider.onValueChanged.AddListener(OnColorChanged);
        }
        if (blueSlider != null)
        {
            blueSlider.onValueChanged.AddListener(OnColorChanged);
        }
        if (confirmButton != null)
        {
            confirmButton.onClick.AddListener(ConfirmColor);
        }
        if (cancelButton != null)
        {
            cancelButton.onClick.AddListener(CancelColor);
        }
    }

    public void SetColor(Color color)
    {
        currentColor = color;
        if (redSlider != null)
        {
            redSlider.value = color.r;
        }
        if (greenSlider != null)
        {
            greenSlider.value = color.g;
        }
        if (blueSlider != null)
        {
            blueSlider.value = color.b;
        }
        UpdateColorPreview();
    }

    private void OnColorChanged(float value)
    {
        currentColor = new Color(redSlider.value, greenSlider.value, blueSlider.value);
        UpdateColorPreview();
    }

    private void UpdateColorPreview()
    {
        if (colorPreview != null)
        {
            colorPreview.color = currentColor;
        }
    }

    private void ConfirmColor()
    {
        OnColorSelected?.Invoke(currentColor);
    }

    private void CancelColor()
    {
        gameObject.SetActive(false);
    }
} 