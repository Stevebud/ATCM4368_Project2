using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemyPawn : ICommand
{
    BoardSpawner _boardSpawner;

    public SpawnEnemyPawn(BoardSpawner boardSpawner)
    {
        _boardSpawner = boardSpawner;
    }

    public void Execute()
    {
        _boardSpawner.SpawnPiece(false, true);
    }

    public void Undo()
    {

    }
}
