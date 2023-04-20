using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    private bool isPaused = false;

    private void OnTriggerEnter(Collider other) 
    {
        
        if(other.gameObject.CompareTag("Character"))
        {
            Character character = other.gameObject.GetComponent<Character>();
            isPaused = !isPaused;
            if (isPaused)
            {
                Time.timeScale = 0; // Tạm dừng scene
            }
            else
            {
                Time.timeScale = 1; // Tiếp tục chạy scene
            }
            switch ((int)character.Type)
            {
                case 0:
                {
                    GameObject gameObject = GameObject.Find("FinishGame");
                    UIManager.Ins.OpenUI(UIID.Finish);
                    break;
                }
                default:
                {
                    GameObject gameObject = GameObject.Find("LoseGame");
                    UIManager.Ins.OpenUI(UIID.Lose);
                    break;
                }
            }
        }
    }
}
