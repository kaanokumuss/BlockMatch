using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Item : MonoBehaviour
{
    public Cell Cell
    {
        get =>_cell;
        set
        {
            if (_cell == value) return;  // varsa birdaha eşitlemeye kalkma 

            var oldCell = _cell;
            _cell = value; // oldcelli tut

            if (oldCell != null && Equals(oldCell.Item , this)) //oldcell null değilse ve eşitse 
            {
                oldCell.Item = null;
            }

            if (value == null) return;

            value.Item = this;
            gameObject.name = _cell.gameObject.name + " " + GetType().Name;


        }
    }
    private Cell _cell;

    public class Factory : PlaceholderFactory<Item>
    {
        
    }
}
