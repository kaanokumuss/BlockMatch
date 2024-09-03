using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Zenject;

public class Cell : MonoBehaviour, ITouchable
{
    [Inject] private Board _board;
    [SerializeField] private TextMeshPro labelText;
    public List<Cell> Neighbors { get; private set; } = new();
    public bool IsFillingCell { get; private set; }

    public Item Item
    {
        get => _item;

        set
        {
            if (_item == value) return; // ayni şeye basıldığında engel olacak yani bir kere alacak.
            {
                var oldItem = _item;
                _item = value; // mesela bir kare disco olacak o zaman burada old item i _item e eşitliyoruz.

                if (oldItem != null && Equals(oldItem.Cell, this))
                {
                    oldItem.Cell = null;
                } // Burada da disco topu gelceği için o cell deki ıtem ı null a çekiyoruz başka yerlerde handlelamamak için 

                if (value != null)
                {
                    value.Cell = this;
                }
            }
        }
    }

    private Item _item;


    public int X { get; private set; }
    public int Y { get; private set; }

    public void Prepare(int x, int y)
    {
        X = x;
        Y = y;
        IsFillingCell = Y == _board.Columns-1;
        transform.localPosition = new Vector3(x, y); // burada cellerimizin pozisyonlarini matrixle eşitliyoruz.  
        SetLabel();
    }

    public bool IsFalling()
    {
        //todo: update here

        return false;
    }

    public bool HasItem()
    {
        return Item != null;
    }
    private void SetLabel()
    {
        var cellName = $"{X}:{Y}";

        labelText.text = cellName;
        gameObject.name = $"Cell {cellName}";
    }

    public class CellFactory : PlaceholderFactory<Cell>
    {
    }
}