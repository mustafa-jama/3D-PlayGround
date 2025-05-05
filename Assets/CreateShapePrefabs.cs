using UnityEngine;

public class CreateShapePrefabs : MonoBehaviour
{
    [ContextMenu("Create Shape Prefabs")]
    public void CreatePrefabs()
    {
        // Create Sphere
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        SetupShapePrefab(sphere, "DraggableSphere");
        DestroyImmediate(sphere);

        // Create Cylinder
        GameObject cylinder = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        SetupShapePrefab(cylinder, "DraggableCylinder");
        DestroyImmediate(cylinder);
    }

    private void SetupShapePrefab(GameObject shape, string prefabName)
    {
        // Add required components
        shape.AddComponent<CubeMover>();
        shape.AddComponent<RotateSelectedObject>();

        // Set up collider
        Collider collider = shape.GetComponent<Collider>();
        if (collider != null)
        {
            collider.isTrigger = false;
        }

        // Set up renderer
        Renderer renderer = shape.GetComponent<Renderer>();
        if (renderer != null)
        {
            renderer.material = new Material(Shader.Find("Standard"));
            renderer.material.color = new Color32(182, 189, 226, 255);
        }

        // Set tag
        shape.tag = "Selectable";

        // Save as prefab
        #if UNITY_EDITOR
        UnityEditor.PrefabUtility.SaveAsPrefabAsset(shape, $"Assets/{prefabName}.prefab");
        #endif
    }
} 