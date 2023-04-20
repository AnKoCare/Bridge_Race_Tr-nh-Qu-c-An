using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : Singleton<GameManager>
{
    //[SerializeField] UserData userData;
    //[SerializeField] CSVData csv;
    private static GameState gameState = GameState.MainMenu;

    // Start is called before the first frame update
    public override void OnInit()
    {
        //base.Awake();
        Input.multiTouchEnabled = false;
        Application.targetFrameRate = 60;
        Screen.sleepTimeout = SleepTimeout.NeverSleep;

        int maxScreenHeight = 1280;
        float ratio = (float)Screen.currentResolution.width / (float)Screen.currentResolution.height;
        if (Screen.currentResolution.height > maxScreenHeight)
        {
            Screen.SetResolution(Mathf.RoundToInt(ratio * (float)maxScreenHeight), maxScreenHeight, true);
        }

        //csv.OnInit();
        //userData?.OnInitData();

        //ChangeState(GameState.MainMenu);
        //UIManager.Ins.OnInit();

    }

    //public static void ChangeState(GameState state)
    //{
    //    gameState = state;
    //}

    //public static bool IsState(GameState state)
    //{
    //    return gameState == state;
    //}

    public void ChangeState(GameState state)
    {
        switch (state)
        {
            case GameState.MainMenu:
                UIManager.Ins.OpenUI(UIID.MainMenu);
                break;
            case GameState.Gameplay:
                UIManager.Ins.CloseUI(UIID.MainMenu);
                UIManager.Ins.OpenUI(UIID.InGame);
                LevelManager.Ins.CharacterStartMoving();
                //cho tat ca character co the di chuyen
                break;
            default:
                break;
        }
    }
}



public enum GameState
{
    MainMenu,
    Gameplay
}
