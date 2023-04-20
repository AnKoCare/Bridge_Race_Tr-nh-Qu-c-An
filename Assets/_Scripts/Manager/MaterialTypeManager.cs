using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialTypeManager : MonoBehaviour
{
    public List<Material> Materials;
    public static Material redMaterial;
    public static Material greenMaterial;
    public static Material blueMaterial;
    public static Material yellowMaterial;
    public static Material whiteMaterial;

    public static MaterialTypeManager instance;

    private void Awake()
    {
        redMaterial = Resources.Load<Material>("_RedMaterial");
        greenMaterial = Resources.Load<Material>("_GreenMaterial");
        blueMaterial = Resources.Load<Material>("_BlueMaterial");
        yellowMaterial = Resources.Load<Material>("_YellowMaterial");
        whiteMaterial = Resources.Load<Material>("_WhiteMaterial");
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public Dictionary<MaterialType, Material> materialMap = new Dictionary<MaterialType, Material>();

    private void Start()
    {
        materialMap[MaterialType.Red] = redMaterial;
        materialMap[MaterialType.Green] = greenMaterial;
        materialMap[MaterialType.Blue] = blueMaterial;
        materialMap[MaterialType.Yellow] = yellowMaterial;
        materialMap[MaterialType.White] = whiteMaterial;
    }

    public Material GetRandomMaterial() {
        Material randomMaterial = Materials[Random.Range(0, Materials.Count - 1)];
        return randomMaterial;
    }

}
public enum MaterialType
    {
        Red = 0,
        Green = 1,
        Blue = 2,
        Yellow = 3,
        White = 4
    }