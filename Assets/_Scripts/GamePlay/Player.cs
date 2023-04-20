using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    [SerializeField] protected MeshRenderer meshRenderer;

    private void Start() 
    {

        // //Set material
        // CodeEnum = 0;
        // meshRenderer.material = MaterialTypeManager.instance.Materials[CodeEnum];
        // Type = (MaterialType)CodeEnum;

        //StartPoint
        //transform.position = new Vector3(StarPoint.transform.position.x, StarPoint.transform.position.y + 1.6f, StarPoint.transform.position.z);
    }
}
