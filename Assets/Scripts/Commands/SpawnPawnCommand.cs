using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPawnCommand : ICommand
{
    BoardSpawner _boardSpawner;

    public SpawnPawnCommand(BoardSpawner boardSpawner)
    {
        _boardSpawner = boardSpawner;
    }

    public void Execute()
    {
        _boardSpawner.SpawnPiece(true, true);
    }

    public void Undo()
    {
        //_boardSpawner.RemovePawn(_spawnedPawn);
    }


}
