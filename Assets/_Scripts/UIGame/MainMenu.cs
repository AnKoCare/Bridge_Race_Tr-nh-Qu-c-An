using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : UICanvas
{
    public void PlayButton()
    {
        for(int i = 0; i < LevelManager.Ins.bots.Count; i++)
        {
            LevelManager.Ins.bots[i].transform.position = LevelManager.Ins.startPoints[i + 1].transform.position;
            LevelManager.Ins.bots[i].NewChangeStateBot();
        }
        //UIManager.Ins.OpenUI(UIID.InGame);
        //Close(0.5f);
        UIManager.Ins.CloseAll();
    }
}
