using System;
using UnityEngine;
using UnityEngine.Experimental.Playables;
using UnityEngine.Rendering.UI;
using Zenject;

public class Board : MonoBehaviour
{
    [SerializeField] private Transform cellParent;
    [Inject] private Cell.CellFactory _cellFactory;
    [Inject] private SignalBus _signalBus;
    
    public int Rows { get; private set; }
    public int Columns { get; private set; }
    public Cell[,] Cells { get; private set;} // Celleri tutacagimiz bir matrix


    private void Awake()
    {
        _signalBus.Subscribe<OnElementTappedSignal>(CellTapped);
    }

    private void OnDestroy()
    {
        _signalBus.Unsubscribe<OnElementTappedSignal>(CellTapped);
    }

    public void Prepare(int row , int columns)
    {
        Rows = row; 
        Columns = columns;
        
        Cells = new Cell[Rows, Columns]; 
        CreateCells(); 
        PrepareCells();
    }

    private void CellTapped(OnElementTappedSignal signal)
    {
        var cell = signal.Touchable.gameObject.GetComponent<Cell>(); // signal ile tikladigimiz gameobjecti aliyoruz. 
    }

    private Cell GetNeighbourWithDirection(Cell cell, Direction direction)
    {
        var x = cell.X;
        var y = cell.Y;

        switch (direction)
        {
            case Direction.None:
                break;
            case Direction.Up:
                y += 1;
                break;
            case Direction.UpRight:
                y += 1;
                x += 1;

                break;
            case Direction.Right:
                x += 1;
                break;
            case Direction.DownRight:
                y -= 1;
                x += 1;
                break;
            case Direction.Down:
                y -= 1;

                break;
            case Direction.DownLeft:
                y -= 1;
                x -= 1;
                break;
            case Direction.Left:
                x -= 1;
                break;
            case Direction.UpLeft:
                y += 1;
                x -= 1;
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(direction), direction, null);
        }

        if (x< 0 || x >= Rows || y<0 || y>=Columns)
        {
            return null;
        }

        return Cells[x, y];
    }

    private void CreateCells()
    {
        for (int x = 0; x < Rows; x++)
        {
            for (int y = 0; y < Columns; y++)
            {
                var cell = _cellFactory.Create(); /// Instantiate etti 
                cell.transform.SetParent(cellParent); // Instantiate edeceği parent  
                Cells[x, y] = cell; // cellimizin matrix değerlerini kaydetti 
            }
        }
    }
    private void PrepareCells() //Cellerimizin içini ayarlıyoruz. 
    {
        for (int x = 0; x < Rows; x++)
        {
            for (int y = 0; y < Columns; y++)
            {
                Cells[x, y].Prepare(x, y);  
            }
        }
    }
    
}
