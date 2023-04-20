using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickStair : MonoBehaviour
{
    [SerializeField] private MeshRenderer meshRenderer;
    [SerializeField] public MaterialType Type;
    private int CodeEnum;

    private void Start() 
    {
        CodeEnum = 4;
        meshRenderer.material = MaterialTypeManager.instance.Materials[CodeEnum];
        Type = (MaterialType)CodeEnum;
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.CompareTag("Character"))
        {
            Character character = other.gameObject.GetComponent<Character>();
            if(character.Type != Type && character.CountBrickBack > 0) 
            {
                GameObject gameObjectDestroy = GameObject.Find("brickback " + (int)character.Type + " " + character.CountBrickBack);
                Destroy(gameObjectDestroy);
                if(character.CountBrickBack > 0)
                {
                    character.CountBrickBack --;
                }
                Type = character.Type;
                meshRenderer.material = MaterialTypeManager.instance.Materials[(int)Type];
            }
        }    
    }
}
