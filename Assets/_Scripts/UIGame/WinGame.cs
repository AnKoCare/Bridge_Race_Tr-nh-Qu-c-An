using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinGame : UICanvas
{
    public void MainMenuButton()
    {
        UIManager.Ins.OpenUI(UIID.MainMenu);
        Close(0.5f);
    }
}
