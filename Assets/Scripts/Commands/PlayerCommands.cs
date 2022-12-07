using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCommands : MonoBehaviour
{
    [SerializeField] BoardSpawner _boardSpawner = null;

    Camera _camera = null;

    CommandInvoker _commandInvoker = new CommandInvoker();

    private void Awake()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        //TODO: Change this to be handled by InputController

        //Spawn Command
        if (Input.GetMouseButtonDown(0))
        {
            //GetNewMouseHit();
            SpawnPawn();
        }
        //Undo last command
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Undo();
        }
    }

    /*
    void GetNewMouseHit()
    {
        //spawn pawn at mouse position
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(ray, out _hitInfo, Mathf.Infinity))
        {
            Debug.Log("Ray hit: " + _hitInfo.transform.name);
        }
    }
    */

    void SpawnPawn()
    {
        //create the command
        ICommand spawnPawnCommand = new SpawnPawnCommand(_boardSpawner);
        //perform the command
        _commandInvoker.ExecuteCommand(spawnPawnCommand);
    }

    void SpawnPlayerQueen()
    {
        ICommand spawnPlayerQueen = new SpawnPlayerQueen(_boardSpawner);
        _commandInvoker.ExecuteCommand(spawnPlayerQueen);
    }

    void SpawnEnemyPawn()
    {
        ICommand spawnEP = new SpawnEnemyPawn(_boardSpawner);
        _commandInvoker.ExecuteCommand(spawnEP);
    }

    void SpawnEnemyQueen()
    {
        ICommand spawnEnemyQueen = new SpawnEnemyQueen(_boardSpawner);
        _commandInvoker.ExecuteCommand(spawnEnemyQueen);
    }

    public void Undo()
    {
        _commandInvoker.UndoCommand();
    }
}
