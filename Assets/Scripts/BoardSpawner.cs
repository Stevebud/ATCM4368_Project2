using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardSpawner : MonoBehaviour
{
    [SerializeField] Piece _pawnPrefab = null;

    public Piece SpawnPawn(Vector3 position)
    {
        //assign the position to the new piece and return it
        Piece newPawn = Instantiate(_pawnPrefab, position, _pawnPrefab.transform.rotation);

        return newPawn;
    }

    public void RemovePawn(Piece pawnToRemove)
    {
        Destroy(pawnToRemove.gameObject);
    }
}
