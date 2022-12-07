using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayerQueen : ICommand
{
    BoardSpawner _boardSpawner;

    public SpawnPlayerQueen(BoardSpawner boardSpawner)
    {
        _boardSpawner = boardSpawner;
    }

    public void Execute()
    {
        _boardSpawner.SpawnPiece(true, false);
    }

    public void Undo()
    {
        
    }
}
