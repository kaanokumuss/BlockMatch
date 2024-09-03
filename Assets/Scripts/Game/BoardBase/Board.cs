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
        // Aldığımız Değerleri olusturduğumuz Rows ve Columns a eşitliyoruz.
        Cells = new Cell[Rows, Columns]; //Cell'imiz boş bir matrixken biz ona değerlerimizi atıyoruz. 
        CreateCells(); //CreateCell methodunu çağırıyoruz.
        PrepareCells();
    }

    private void CellTapped(OnElementTappedSignal signal)
    {
        var cell = signal.Touchable.gameObject.GetComponent<Cell>(); // signal ile tikladigimiz gameobjecti aliyoruz. 
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
