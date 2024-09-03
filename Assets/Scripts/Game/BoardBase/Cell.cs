using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Zenject;

public class Cell : MonoBehaviour
{
    [SerializeField] private TextMeshPro labelText;
    [SerializeField] private Board _board;
    public List<Cell> Neighbors { get; private set; } = new();
    public int X { get; private set; }
    public int Y { get; private set; }
    public void Prepare(int x, int y)
    {
        X = x;
        Y = y;

        transform.localPosition = new Vector3(x, y); // burada cellerimizin pozisyonlarini matrixle eşitliyoruz.  
        SetLabel();
    }

    private void SetLabel()
    {
        var cellName = $"{X}:{Y}";

        labelText.text = cellName;
        gameObject.name =$"Cell {cellName}";


    }
   
    public class CellFactory : PlaceholderFactory<Cell>{ }
}
