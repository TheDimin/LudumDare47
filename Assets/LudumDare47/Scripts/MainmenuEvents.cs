using System.Collections;
using System.Collections.Generic;
using LD47;
using LD47.GameStates;
using UnityEngine;

public class MainmenuEvents : MonoBehaviour
{
    public void OnPlayGame()
    {
        GameManager.Instance.StateManager.FindState<PreGameState>().EnterGame();
      
    }

    public void OnExitGame()
    {
        Application.Quit();
    }
}
