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
        GameManager.Instance.StateManager.BindOnStateChange((newState) =>
        {

        });
    }

    public void OnExitGame()
    {
        Application.Quit();
    }
}
