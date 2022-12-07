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
    [SerializeField] GameObject _selectionHighight = null;

    //private RectTransform _thisRectTransform;
    private int _pawnNum;
    private int _queenNum;
    private bool _hasSelection;
    
    [SerializeField] Image[,] images;
    /*
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
    */

    private void Start()
    {
        Setup();
        UpdateDisplay();
    }

    //public function that changes internal values
    public void ChangeNumberDisplayed(int pawnChange, int queenChange)
    {
        _pawnNum += pawnChange;
        _queenNum += queenChange;
        UpdateDisplay();
    }

    private void Setup()
    {
        //_thisRectTransform = GetComponent<RectTransform>();
        
        images = new Image[_gridSize, _gridSize];
        for (int j = 0; j < _gridSize; j++)
        {
            for (int k = 0; k < _gridSize; k++)
            {
                //make the image
                images[j, k] = Instantiate(_emptyImage, transform);
                //set the image
                if (k < 2)
                {
                    images[j, k].sprite = _pawn;
                }
                else
                {
                    images[j, k].sprite = _queen;
                }
                //move into position
                RectTransform _rectTransform = images[j, k].rectTransform;
                _rectTransform.Translate(-78 + j * 50, -68 + k * 50, 0f, Space.Self);
                images[j, k].gameObject.SetActive(false);
            }
        }

        /*
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
        */
    }

    private void UpdateDisplay()
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
        //pawns
        for (int i = 0; i < _gridSize*3/2; i++)
        {
            if (i < _pawnNum)
            {
                images[i % _gridSize, (i / _gridSize) % _gridSize].gameObject.SetActive(true);
            }
            else
            {
                images[i % _gridSize, (i / _gridSize) % _gridSize].gameObject.SetActive(false);
            }
        }
        //queens
        for (int i = 0; i < _gridSize * 3 / 2; i++)
        {
            if (i < _queenNum)
            {
                images[(i % 4), _gridSize/2 + (i / 4) % 4].gameObject.SetActive(true);
            }
            else
            {
                images[(i % 4), _gridSize/2 + (i / 4) % 4].gameObject.SetActive(false);
            }
        }
    }

    public void SetSelection(bool hasSelection)
    {
        _hasSelection = hasSelection;
        _selectionHighight.SetActive(hasSelection);
    }
}
