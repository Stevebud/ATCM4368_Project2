using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LoseState : CardGameState
{
    public static event Action LoseStateStart;
    public static event Action LoseStateEnd;

    public override void Enter()
    {
        Debug.Log("Player Lost. Lose State... Entering");
        //call Start events
        LoseStateStart?.Invoke();
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
        Debug.Log("Lose State Exiting...");
        //Call end events
        LoseStateEnd?.Invoke();
        //unhook from events
        StateMachine.Input.PressedConfirm -= OnConfirmPressed;
    }

    private void OnConfirmPressed()
    {
        StateMachine.ChangeState<MainMenuState>();
        StateMachine.Input.PlayClip2D();
    }
}
