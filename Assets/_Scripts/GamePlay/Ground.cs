using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    public List<Brick> brickground = new List<Brick>();
    //[SerializeField] public List<Material> Materials;
    [SerializeField] public List<MaterialType> Materials;
    public List <Bridge> bridges = new List<Bridge>(3);
    protected MaterialType Type;
    public int countBrick = 5;
    public Brick brickPrefab;
    private float timeRespawn = 0;
    List<Brick> deactiveList = new();
    private static Ground instance;

    public static Ground Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<Ground>();
            }
            return instance;
        }
    }

    private void Start() 
    {
        SpawnBrickGround();
    }

    private void Update() 
    {
        if(timeRespawn < 0.5f)
        {
            timeRespawn += Time.deltaTime;
        }
        else
        {
            timeRespawn = 0;
            Respawn();
        }
    }

    private void Respawn()
    {
        if (deactiveList.Count == 0 || Materials.Count == 0)
        {
            return;
        }
        int randomIndex = Random.Range(0, deactiveList.Count);
        int randomType = Random.Range(0, Materials.Count);

        //Set Type and Material
        deactiveList[randomIndex].meshRenderer.material = MaterialTypeManager.instance.materialMap[Materials[randomType]];
        deactiveList[randomIndex].Type = Materials[randomType];

        //Set Active 
        deactiveList[randomIndex].gameObject.SetActive(true);

        //Remove object
        deactiveList.RemoveAt(randomIndex);
    }

    public void SpawnBrickGround()
    {
        //Spawn brick ground 1
        for(int i = 0; i < countBrick; i++)
        {
            for(int j = 0; j < countBrick; j++)
            {
                Brick brick = SimplePool.Spawn<Brick>(brickPrefab);
                brick.transform.SetParent(transform);

                // brick position
                Vector3 PosBrickIns = new Vector3( 0.08f*i - 0.35f, 0.502f, 0.08f*j - 0.35f);
                brick.transform.localPosition = PosBrickIns;

                //Set material
                if (this.Materials.Count > 0)
                {
                    int randomMesh = Random.Range(0, this.Materials.Count);

                    brick.meshRenderer.material = MaterialTypeManager.instance.materialMap[Materials[randomMesh]];
                    brick.Type = this.Materials[randomMesh];
                }
                else
                {
                    brick.gameObject.SetActive(false);
                    deactiveList.Add(brick);
                }
                
                //Update Brick
                brick.index = i + j;
                brickground.Add(brick);
            }
        }
    }

    public void SpawnNewBrick(MaterialType type)
    {
        for (int i = 0; i < 10; i++)
        {
            int randomIndex = Random.Range(0, deactiveList.Count);
            deactiveList[randomIndex].meshRenderer.material = MaterialTypeManager.instance.materialMap[type];
            deactiveList[randomIndex].Type = type;
            deactiveList[randomIndex].gameObject.SetActive(true);
            deactiveList.RemoveAt(randomIndex);
        }
    }

    public void Despawn(Brick brick)
    {
        brick.gameObject.SetActive(false);
        deactiveList.Add(brick);
    }
}
