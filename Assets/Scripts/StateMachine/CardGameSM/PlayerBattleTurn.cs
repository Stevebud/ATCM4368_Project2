using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerBattleTurn : CardGameState
{
    public static event Action PlayerBattleTurnStart;
    public static event Action PlayerBattleTurnEnd;

    public override void Enter()
    {
        Debug.Log("Player Battle Turn... Entering");
        PlayerBattleTurnStart?.Invoke();
        //hook on to events
        StateMachine.Input.PressedRight += OnPressedRight;
        StateMachine.Input.PressedLeft += OnPressedLeft;
        StateMachine.Input.PressedConfirm += OnPressedConfirm;
    }

    /*
    public override void Tick()
    {
        
    }
    */

    public override void Exit()
    {
        Debug.Log("Player Battle Turn Exiting...");
        PlayerBattleTurnEnd?.Invoke();
        //unattatch to events
        StateMachine.Input.PressedRight -= OnPressedRight;
        StateMachine.Input.PressedLeft -= OnPressedLeft;
        StateMachine.Input.PressedConfirm -= OnPressedConfirm;
    }

    void OnPressedConfirm()
    {
        //change the enemy battle turn state
        StateMachine.ChangeState<EnemyBattleTurn>();
    }

    void OnPressedRight()
    {
        //Change to win state
        StateMachine.ChangeState<WinState>();
    }

    void OnPressedLeft()
    {
        //Change to lose state
        StateMachine.ChangeState<LoseState>();
    }
}
