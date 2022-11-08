using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerTurnCardGameState : CardGameState
{
    [SerializeField] CanvasRenderer _playerTurnPanel = null;
    [SerializeField] Text _playerTurnText = null;

    int _playerTurnCount = 0;

    public override void Enter()
    {
        Debug.Log("Player Turn: ...Entering");
        _playerTurnPanel.gameObject.SetActive(true);

        _playerTurnCount++;
        _playerTurnText.text = "This is where players commit their pieces to the next battle.";
        //hook into events
        StateMachine.Input.PressedConfirm += OnPressedConfirm;
        StateMachine.Input.PressedRight += OnPressedRight;
    }

    public override void Exit()
    {
        _playerTurnPanel.gameObject.SetActive(false);
        //unhook events
        StateMachine.Input.PressedConfirm -= OnPressedConfirm;
        StateMachine.Input.PressedRight -= OnPressedRight;

        Debug.Log("Player Turn: Exiting...");
    }

    void OnPressedConfirm()
    {
        //change the enemy turn state
        StateMachine.ChangeState<EnemyTurnCardGameState>();
    }

    void OnPressedRight()
    {
        //Change to playerBattle state
        StateMachine.ChangeState<PlayerBattleTurn>();
    }
}
