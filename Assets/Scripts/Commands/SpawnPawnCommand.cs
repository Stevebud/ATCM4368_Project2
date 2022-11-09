using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPawnCommand : ICommand
{
    BoardSpawner _boardSpawner;
    Vector3 _position;

    Piece _spawnedPawn;

    public SpawnPawnCommand(BoardSpawner boardSpawner, Vector3 position)
    {
        _boardSpawner = boardSpawner;
        _position = position;
    }

    public void Execute()
    {
        _spawnedPawn = _boardSpawner.SpawnPawn(_position);
    }

    public void Undo()
    {
        _boardSpawner.RemovePawn(_spawnedPawn);
    }


}
