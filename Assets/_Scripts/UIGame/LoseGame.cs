using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseGame : UICanvas
{
    public void MainMenuButton()
    {
        UIManager.Ins.CloseAll();
        Reload();
        Debug.Log("reload");
        Time.timeScale = 1;
        //UIManager.Ins.OpenUI(UIID.MainMenu);
        //Close(0.5f);
    }

    public void Reload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
