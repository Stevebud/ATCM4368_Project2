using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasRenderer))]
public class PieceDisplayPanel : MonoBehaviour
{
    [SerializeField] bool _forPlayer = false;
    [SerializeField] PieceManager _pieceManager = null;
    [SerializeField] Image _emptyImage = null;
    [SerializeField] Sprite _pawn = null;
    [SerializeField] Sprite _queen = null;
    [SerializeField] int _gridSize = 4;

    //private RectTransform _thisRectTransform;
    private int _pawnNum;
    private int _queenNum;
    [SerializeField] Image[,] images;
    [SerializeField] Image A1;
    [SerializeField] Image A2;
    [SerializeField] Image A3;
    [SerializeField] Image A4;
    [SerializeField] Image B1;
    [SerializeField] Image B2;
    [SerializeField] Image B3;
    [SerializeField] Image B4;
    [SerializeField] Image C1;
    [SerializeField] Image C2;
    [SerializeField] Image C3;
    [SerializeField] Image C4;
    [SerializeField] Image D1;
    [SerializeField] Image D2;
    [SerializeField] Image D3;
    [SerializeField] Image D4;

    private void Start()
    {
        Setup();
        UpdateDisplay();
    }

    public void Setup()
    {
        //_thisRectTransform = GetComponent<RectTransform>();
        /*
        images = new Image[_gridSize, _gridSize];
        for (int j = 0; j < _gridSize; j++)
        {
            for (int k = 0; k < _gridSize; k++)
            {
                images[j, k] = Instantiate(_emptyImage, transform);
                //move into position
                RectTransform _rectTransform = images[j, k].rectTransform;
                _rectTransform.Translate(-100 + j * 50, -100 + k * 50, 0f, Space.Self);
            }
        }
        */
        images = new Image[_gridSize, _gridSize];
        images[0, 0] = A1;
        images[1, 0] = A2;
        images[2, 0] = A3;
        images[3, 0] = A4;
        images[0, 1] = B1;
        images[1, 1] = B2;
        images[2, 1] = B3;
        images[3, 1] = B4;
        images[0, 2] = C1;
        images[1, 2] = C2;
        images[2, 2] = C3;
        images[3, 2] = C4;
        images[0, 3] = D1;
        images[1, 3] = D2;
        images[2, 3] = D3;
        images[3, 3] = D4;
    }

    public void UpdateDisplay()
    {
        if (_forPlayer)
        {
            //update values
            _pawnNum = _pieceManager._playerAvailablePawns;
            _queenNum = _pieceManager._playerAvailableQueens;
        }
        else
        {
            _pawnNum = _pieceManager._enemyAvailablePawns;
            _queenNum = _pieceManager._enemyAvailableQueens;
        }

        //update UI
        for (int i = 0; i < _pawnNum; i++)
        {
            images[i % _gridSize, (i / 4) % 4].sprite = _pawn;
        }
        for (int i = 0; i < _queenNum; i++)
        {
            images[(i % 4), 3+(i / 4) % 4].sprite = _queen;
        }
    }

}
