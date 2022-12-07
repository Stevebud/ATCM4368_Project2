using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardGameUIController : MonoBehaviour
{
    [SerializeField] CanvasRenderer _playerBettingPanel = null;
    [SerializeField] CanvasRenderer _enemyBettingPanel = null;
    [SerializeField] CanvasRenderer _victoryPanel = null;
    [SerializeField] CanvasRenderer _lossPanel = null;
    [SerializeField] CanvasRenderer _mainMenuPanel = null;
    [SerializeField] CanvasRenderer _playerBattlePanel = null;
    [SerializeField] CanvasRenderer _enemyBattlePanel = null;

    private void OnEnable()
    {
        PlayerTurnCardGameState.PlayerBettingTurnBegan += OnPlayerBettingTurnBegan;
        PlayerTurnCardGameState.PlayerBettingTurnEnded += OnPlayerBettingTurnEnded;
        EnemyTurnCardGameState.EnemyTurnBegan += OnEnemyTurnBegan;
        EnemyTurnCardGameState.EnemyTurnEnded += OnEnemyTurnEnded;
        WinState.WinStateStart += OnWinStart;
        WinState.WinStateEnd += OnWinEnd;
        LoseState.LoseStateStart += OnLoseStart;
        LoseState.LoseStateEnd += OnLoseEnd;
        MainMenuState.MainMenuEnter += OnMainMenuEnter;
        MainMenuState.MainMenuExit += OnMainMenuExit;
        PlayerBattleTurn.PlayerBattleTurnStart += OnPlayerBattleEnter;
        PlayerBattleTurn.PlayerBattleTurnEnd += OnPlayerBattleExit;
        EnemyBattleTurn.EnemyBattleTurnStart += OnEnemyBattleEnter;
        EnemyBattleTurn.EnemyBattleTurnEnd += OnEnemyBattleExit;
    }

    private void OnDisable()
    {
        PlayerTurnCardGameState.PlayerBettingTurnBegan -= OnPlayerBettingTurnBegan;
        PlayerTurnCardGameState.PlayerBettingTurnEnded -= OnPlayerBettingTurnEnded;
        EnemyTurnCardGameState.EnemyTurnBegan -= OnEnemyTurnBegan;
        EnemyTurnCardGameState.EnemyTurnEnded -= OnEnemyTurnEnded;
        WinState.WinStateStart -= OnWinStart;
        WinState.WinStateEnd -= OnWinEnd;
        LoseState.LoseStateStart -= OnLoseStart;
        LoseState.LoseStateEnd -= OnLoseEnd;
        MainMenuState.MainMenuEnter -= OnMainMenuEnter;
        MainMenuState.MainMenuExit -= OnMainMenuExit;
        PlayerBattleTurn.PlayerBattleTurnStart -= OnPlayerBattleEnter;
        PlayerBattleTurn.PlayerBattleTurnEnd -= OnPlayerBattleExit;
        EnemyBattleTurn.EnemyBattleTurnStart -= OnEnemyBattleEnter;
        EnemyBattleTurn.EnemyBattleTurnEnd -= OnEnemyBattleExit;
    }

    private void Start()
    {
        //make sure text is disabled on start
        _playerBettingPanel.gameObject.SetActive(false);
        _enemyBettingPanel.gameObject.SetActive(false);
        _victoryPanel.gameObject.SetActive(false);
        _lossPanel.gameObject.SetActive(false);
        _playerBattlePanel.gameObject.SetActive(false);
        _enemyBattlePanel.gameObject.SetActive(false);
    }

    void OnPlayerBettingTurnBegan()
    {
        _playerBettingPanel.gameObject.SetActive(true);
    }

    void OnPlayerBettingTurnEnded()
    {
        _playerBettingPanel.gameObject.SetActive(false);
    }

    void OnEnemyTurnBegan()
    {
        _enemyBettingPanel.gameObject.SetActive(true);
    }

    void OnEnemyTurnEnded()
    {
        _enemyBettingPanel.gameObject.SetActive(false);
    }

    private void OnWinStart()
    {
        _victoryPanel.gameObject.SetActive(true);
    }

    private void OnWinEnd()
    {
        _victoryPanel.gameObject.SetActive(false);
    }
    private void OnLoseStart()
    {
        _lossPanel.gameObject.SetActive(true);
    }

    private void OnLoseEnd()
    {
        _lossPanel.gameObject.SetActive(false);
    }

    private void OnMainMenuEnter()
    {
        _mainMenuPanel.gameObject.SetActive(true);
    }

    private void OnMainMenuExit()
    {
        _mainMenuPanel.gameObject.SetActive(false);
    }

    private void OnPlayerBattleEnter()
    {
        _playerBattlePanel.gameObject.SetActive(true);
    }

    private void OnPlayerBattleExit()
    {
        _playerBattlePanel.gameObject.SetActive(false);
    }

    private void OnEnemyBattleEnter()
    {
        _enemyBattlePanel.gameObject.SetActive(true);
    }

    private void OnEnemyBattleExit()
    {
        _enemyBattlePanel.gameObject.SetActive(false);
    }
}
