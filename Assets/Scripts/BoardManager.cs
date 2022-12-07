using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.UIElements;

public class BoardManager : MonoBehaviour
{
    public int _boardDimensions = 8;
    [SerializeField] Image _emptyWhite = null;
    [SerializeField] Image _availableTileHighight = null;
    [SerializeField] GameObject _selectedTileHighight = null;
    [SerializeField] PieceManager _pieceManager = null;

    private Image[,] _boardSpaceArray = new Image[8,8];
    private int[,] _boardStateArray = new int[8, 8];
    public bool _hasSelection { get; set; }
    private bool[,] _cursorState = new bool[8, 8];

    private int _playerPawns = 0;
    private int _enemyPawns = 0;
    private int _playerQueens = 0;
    private int _enemyQueens = 0;

    /* Board State Legend
    0-Empty
    1-White(Player) Pawn
    2-White(Player) Queen
    3-Black Pawn
    4-Black Queen
    */

    private void Start()
    {
        SetupEmptyBoard();
        SetSelection(false);
    }

    public void SetupEmptyBoard()
    {
        for(int col=0; col<_boardDimensions; col++)
        {
            //run 8 times
            for (int row = 0; row < _boardDimensions; row++)
            {
                //run 8 times
                //create the space
                _boardSpaceArray[col, row] = Instantiate(_emptyWhite, transform);
                //_boardPieceArray[col, row] = Instantiate(_emptyWhite, transform);
                //move into position
                RectTransform _spaceRectTransform = _boardSpaceArray[col, row].rectTransform;
                _spaceRectTransform.Translate(-175 + col * 50, -175 + row * 50, 0f, Space.Self);
                _boardSpaceArray[col, row].gameObject.SetActive(false);
                //RectTransform _piecesRectTransform = _boardPieceArray[col, row].rectTransform;
                //_piecesRectTransform.Translate(-175 + col * 50, -175 + row * 50, 0f, Space.Self);

            }
        }
    }

    public void setTileState(int column, int row, int newState)
    {
        int prevState = _boardStateArray[column, row];
        if(prevState == 1)
        {
            _pieceManager.EnemyCapturePawn();
        }
        else if(prevState == 2)
        {
            _pieceManager.EnemyCaptureQueen();
        }
        else if(prevState == 3)
        {
            _pieceManager.PlayerCapturePawn();
        }
        else if(prevState == 4)
        {
            _pieceManager.PlayerCaptureQueen();
        }
        _boardStateArray[column, row] = newState;
    }

    public int getTileState(int column, int row)
    {
        return _boardStateArray[column, row];
    }

    private bool checkTileOpen(int column, int row)
    {
        if(_boardStateArray[column, row] == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void SetSelection(bool hasSelection)
    {
        _hasSelection = hasSelection;
        _selectedTileHighight.SetActive(hasSelection);
    }
}
