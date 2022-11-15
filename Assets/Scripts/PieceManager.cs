using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceManager : MonoBehaviour
{
    [SerializeField] int _startingQueens = 1;
    [SerializeField] int _startingPawns = 4;
    public int _playerAvailablePawns { get; set; }
    public int _enemyAvailablePawns { get; set; }
    public int _playerAvailableQueens { get; set; }
    public int _enemyAvailableQueens { get; set; }

    public void Setup()
    {
        //restore starting values
        _playerAvailablePawns = _startingPawns;
        _enemyAvailablePawns = _startingPawns;
        _playerAvailableQueens = _startingQueens;
        _enemyAvailableQueens = _startingQueens;
    }

    public void PlayerCapturePawn()
    {
        _enemyAvailablePawns--;
        _playerAvailablePawns++;
    }

    public void PlayerCaptureQueen()
    {
        _enemyAvailableQueens--;
        _playerAvailableQueens++;
    }

    public void EnemyCapturePawn()
    {
        _enemyAvailablePawns++;
        _playerAvailablePawns--;
    }

    public void EnemyCaptureQueen()
    {
        _enemyAvailableQueens++;
        _playerAvailableQueens--;
    }
}
