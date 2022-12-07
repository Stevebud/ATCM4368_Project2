using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemyQueen : ICommand
{
    BoardSpawner _boardSpawner;

    public SpawnEnemyQueen(BoardSpawner boardSpawner)
    {
        _boardSpawner = boardSpawner;
    }

    public void Execute()
    {
        _boardSpawner.SpawnPiece(false, false);
    }

    public void Undo()
    {

    }
}
