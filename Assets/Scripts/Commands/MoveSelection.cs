using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSelection : ICommand
{
    BoardSpawner _boardSpawner;
    GameObject selectionHighlight;

    public MoveSelection(BoardSpawner boardSpawner, GameObject selectHighlight)
    {
        _boardSpawner = boardSpawner;
        selectionHighlight = selectHighlight;
    }

    public void Execute()
    {
        _boardSpawner.SpawnPiece(false, false);
    }

    public void Undo()
    {

    }
}
