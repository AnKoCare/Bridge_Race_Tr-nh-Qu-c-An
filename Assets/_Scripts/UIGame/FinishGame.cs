using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishGame : UICanvas
{
        
    public void MainMenuButton()
    {
        UIManager.Ins.CloseAll();
        Reload();
        //UIManager.Ins.OpenUI(UIID.MainMenu);
        Time.timeScale = 1;
        //Close(0.5f);
    }

    public void Reload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
