using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : GameUnit
{
    public MeshRenderer meshRenderer;
    public MaterialType type;
    public int index;
    public MaterialType Type
    {
        get => type;
        set
        {
            type = value;
            meshRenderer.material = MaterialTypeManager.instance.Materials[(int)value];
        }
    }
}
