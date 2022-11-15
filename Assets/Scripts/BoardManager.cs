using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.UIElements;

public class BoardManager : MonoBehaviour
{
    [SerializeField] int _boardDimensions = 8;
    [SerializeField] Image _emptyWhite = null;
    [SerializeField] Image _availableTileHighight = null;
    [SerializeField] Image _selectedTileHighight = null;

    private Image[,] _boardSpaceArray = new Image[8,8];
    private Image[,] _boardPieceArray = new Image[8, 8];

    private void Start()
    {
        setupEmptyBoard();
    }

    public void setupEmptyBoard()
    {
        for(int col=0; col<_boardDimensions; col++)
        {
            //run 8 times
            for (int row = 0; row < _boardDimensions; row++)
            {
                //run 8 times
                //create the space
                _boardSpaceArray[col, row] = Instantiate(_emptyWhite, transform);
                _boardPieceArray[col, row] = Instantiate(_emptyWhite, transform);
                //move into position
                RectTransform _spaceRectTransform = _boardSpaceArray[col, row].rectTransform;
                _spaceRectTransform.Translate(-175 + col * 50, -175 + row * 50, 0f, Space.Self);
                RectTransform _piecesRectTransform = _boardPieceArray[col, row].rectTransform;
                _piecesRectTransform.Translate(-175 + col * 50, -175 + row * 50, 0f, Space.Self);

            }
        }
    }
    
}
