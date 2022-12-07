using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class WinState : CardGameState
{

    public static event Action WinStateStart;
    public static event Action WinStateEnd;

    public override void Enter()
    {
        Debug.Log("Player Won! Win State... Entering");
        //call Start events
        WinStateStart?.Invoke();
        //hook into events
        StateMachine.Input.PressedConfirm += OnConfirmPressed;
    }

    /*
    public override void Tick()
    {
        
    }
    */

    public override void Exit()
    {
        Debug.Log("Win State Exiting...");
        //Call end events
        WinStateEnd?.Invoke();
        //unhook from events
        StateMachine.Input.PressedConfirm -= OnConfirmPressed;
    }

    private void OnConfirmPressed()
    {
        StateMachine.ChangeState<MainMenuState>();
        StateMachine.Input.PlayClip2D();
    }
}