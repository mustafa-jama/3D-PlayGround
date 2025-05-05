using UnityEngine;

public class ColorTextureSelector : MonoBehaviour
{
    public static ColorTextureSelector Instance { get; private set; }

    public bool IsColorSelected { get; private set; } = true;
    public Color SelectedColor { get; private set; } = Color.yellow;
    public Texture2D SelectedTexture { get; private set; } = null;


    public void TestFunction()
    {
        Debug.Log("TestFunction called");
    }
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }
        Instance = this;
    }

    public void SetColor(Color color)
    {
        SelectedColor = color;
        IsColorSelected = true;
        SelectedTexture = null;
    }

    public void SetTexture(Texture2D texture)
    {
        SelectedTexture = texture;
        IsColorSelected = false;
    }
} 