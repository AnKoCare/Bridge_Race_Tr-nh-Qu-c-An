using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlay : UICanvas
{
    public void WinButton()
    {
        UIManager.Ins.OpenUI(UIID.Win);//.score.text = Random.Range(100, 200).ToString();
        Close(0);
    }

    public void LoseButton()
    {
        UIManager.Ins.OpenUI(UIID.Lose);//.score.text = Random.Range(0, 100).ToString(); 
        Close(0);
    }
}
