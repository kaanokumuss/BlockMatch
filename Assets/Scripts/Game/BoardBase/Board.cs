using UnityEngine;
using UnityEngine.Experimental.Playables;
using UnityEngine.Rendering.UI;
using Zenject;

public class Board : MonoBehaviour
{
    [SerializeField] private Transform cellParent;
    [Inject] private Cell.CellFactory _cellFactory;
    
    public int Rows { get; private set; }
    public int Columns { get; private set; }
    public Cell[,] Cells { get; private set;} // Celleri tutacagimiz bir matrix

    public void Prepare(int row , int columns)
    {
        Rows = row;
        Columns = columns;

        Cells = new Cell[Rows, Columns];

        CreateCells();
        
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
}
