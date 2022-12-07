using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardSpawner : MonoBehaviour
{
    [SerializeField] Piece _pawnPrefab = null;
    [SerializeField] BoardManager _boardManager = null;

    public void SpawnPiece(bool forPlayer, bool isPawn)
    {
        int desiredState = 0;
        int spawnCol = 0;
        int spawnRow = 0;
        //check which piece to spawn
        if (forPlayer && isPawn)
        {
            desiredState = 1;
        }
        else if (forPlayer && !isPawn)
        {
            desiredState = 2;
        }
        else if (!forPlayer && isPawn)
        {
            desiredState = 3;
        }
        else if(!forPlayer && !isPawn)
        {
            desiredState = 4;
        }
        //check which row to start the piece on
        if (forPlayer)
        {
            spawnRow = 7;
        }

        //check which spot is empty on the starting row
        for(int i = 0; i<_boardManager._boardDimensions; i++)
        {
            if(_boardManager.getTileState(i, spawnRow) == 0)
            {
                spawnCol = i;
                break;
            }
        }

        //assign the position to the new piece
        _boardManager.setTileState(spawnCol, spawnRow, desiredState);
    }

    public void RemovePawn(Piece pawnToRemove)
    {
        Destroy(pawnToRemove.gameObject);
    }
}
