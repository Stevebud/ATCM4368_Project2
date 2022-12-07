using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class MainMenuState : CardGameState
{
    public static event Action MainMenuEnter;
    public static event Action MainMenuExit;

    public override void Enter()
    {
        Debug.Log("Main Menu... Entering");
        MainMenuEnter?.Invoke();
    }

    /*
    public override void Tick()
    {
        
    }
    */

    public override void Exit()
    {
        Debug.Log("Main Menu Exiting...");
        MainMenuExit?.Invoke();
    }

    public void OnStartGameClicked()
    {
        StateMachine.ChangeState<SetupCardGameState>();
        StateMachine.Input.PlayClip2D();
    }

    public void OnExitClicked()
    {
        Application.Quit();
    }
}
