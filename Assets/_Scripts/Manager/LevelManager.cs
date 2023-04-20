using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : Singleton<LevelManager>
{
    public List<Level> levels = new List<Level>();
    Level currentLevel;
    [SerializeField] private List<Ground> grounds;
    [SerializeField] public List<Bot> bots;
    [SerializeField] public List<GameObject> startPoints;
    private int numberOfBots = 3;


    public void LoadLevel(int indexLevel)
    {
        if(currentLevel != null)
        {
            Destroy(currentLevel.gameObject);
        }

        currentLevel = Instantiate(levels[indexLevel - 1]);
    }

    public override void OnInit()
    {

    }

    public void OnStart()
    {

    }

    public void OnFinish()
    {

    }
    public Ground getGround(int index){
        return index<grounds.Count&&index>-1?grounds[index]:null;
    }
    public void CharacterStartMoving()
    {

    }
}
