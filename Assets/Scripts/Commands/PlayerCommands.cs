using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCommands : MonoBehaviour
{
    [SerializeField] BoardSpawner _boardSpawner = null;

    Camera _camera = null;
    RaycastHit _hitInfo;

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
            GetNewMouseHit();
            SpawnPawn();
        }
        //Undo last command
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Undo();
        }
    }

    void GetNewMouseHit()
    {
        //spawn pawn at mouse position
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(ray, out _hitInfo, Mathf.Infinity))
        {
            Debug.Log("Ray hit: " + _hitInfo.transform.name);
        }
    }

    void SpawnPawn()
    {
        //create the command
        ICommand spawnPawnCommand = new SpawnPawnCommand(_boardSpawner, _hitInfo.point);
        //perform the command
        _commandInvoker.ExecuteCommand(spawnPawnCommand);
    }

    public void Undo()
    {
        _commandInvoker.UndoCommand();
    }
}
