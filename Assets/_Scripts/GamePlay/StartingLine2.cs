using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingLine2 : MonoBehaviour
{
    [SerializeField] private Ground prevGround;
    [SerializeField] private Ground nextGround;

    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.CompareTag("Character"))
        {
            Character character = other.gameObject.GetComponent<Character>();
            if(character.CountSpawnBrick == 1)
            {
                return;
            }
            for (int i = 0; i < prevGround.Materials.Count; i ++){
                if (prevGround.Materials[i] == character.Type){
                    prevGround.Materials.RemoveAt(i);
                    break;
                }
            }
            for(int i = 0; i < prevGround.brickground.Count; i++)
            {
                if(prevGround.brickground[i].Type == character.Type)
                {
                    prevGround.Despawn(prevGround.brickground[i]);
                }
            }
            character.currentGround = nextGround;
            if (nextGround != null){
                nextGround.Materials.Add(character.Type);
                nextGround.SpawnNewBrick(character.Type);
            }
            character.CountSpawnBrick ++;
        }   
    }
}
