using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class PlayerTurnCardGameState : CardGameState
{
    public static event Action PlayerBettingTurnBegan;
    public static event Action PlayerBettingTurnEnded;

    [SerializeField] CanvasRenderer _playerTurnPanel = null;
    [SerializeField] Text _playerTurnText = null;
    [SerializeField] PieceDisplayPanel _pieceDisplayPanel= null;
    [SerializeField] BoardManager _boardManager = null;

    int _playerTurnCount = 0;
    int _playerTurnState = 0;

    /* PlayerTurnState Legend
    0-Not turn
    1-SelectingFromAvailable
    2-PlacingChosenPiece
    3-Passed?
    */

    public override void Enter()
    {
        Debug.Log("Player Turn: ...Entering");
        PlayerBettingTurnBegan.Invoke();
        _playerTurnState = 1;
        _playerTurnCount++;
        _playerTurnText.text = "This is where players commit their pieces to the next battle.";
        //hook into events
        StateMachine.Input.PressedConfirm += OnPressedConfirm;
        StateMachine.Input.PressedRight += OnPressedRight;
    }

    public override void Exit()
    {
        PlayerBettingTurnEnded.Invoke();
        _playerTurnState = 0;
        //unhook events
        StateMachine.Input.PressedConfirm -= OnPressedConfirm;
        StateMachine.Input.PressedRight -= OnPressedRight;

        Debug.Log("Player Turn: Exiting...");
    }

    void OnPressedConfirm()
    {
        //change the enemy turn state
        StateMachine.ChangeState<EnemyTurnCardGameState>();
        StateMachine.Input.PlayClip2D();
    }

    void OnPressedRight()
    {
        //Change to playerBattle state
        StateMachine.ChangeState<PlayerBattleTurn>();
        StateMachine.Input.PlayClip2D();
    }
}
