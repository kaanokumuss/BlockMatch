using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class RocketItem : SpecialItem
{
    [Inject] private ImageLibService _imageLibService;
    [Inject] private Board _board;
    
    public void PrepareRocketItem(ItemBase itemBase, ItemType itemType)
    {
        ItemType = itemType;
        var sprite = GetDefaultItemSprite();
        Prepare(itemBase, sprite);
    }

    protected override Sprite GetDefaultItemSprite()
    {
        return ItemType switch
        {
            ItemType.VerticalRocket => _imageLibService.Images.rocketVertical,
            ItemType.HorizontalRocket => _imageLibService.Images.rocketHorizontal,
            _ => throw new ArgumentOutOfRangeException()
        };
    }

    public override void TryExecute()
    {
        var explosionCells = GetExplosionCells();
        
        base.TryExecute();

        for (var i = 0; i < explosionCells.Count; i++)
        {
            if (explosionCells[i].HasItem())
            {
                explosionCells[i].Item.TryExecute();
            }
        }
    }

    protected override List<Cell> GetExplosionCells()
    {
        var explodingCells = new List<Cell>();

        var x = this.Cell.X;
        var y = this.Cell.Y;

        if (ItemType == ItemType.HorizontalRocket)
        {
            for (int i = -_board.Rows; i <= _board.Rows; i++)
            {
                if (!_board.IsInBoardX(x + i)) continue;
                
                var cell = _board.Cells[x + i, y];

                if (cell.HasItem())
                {
                    explodingCells.Add(cell);
                }
            }
        }
        else if (ItemType == ItemType.VerticalRocket)
        {
            for (int j = -_board.Cols; j <= _board.Cols; j++)
            {
                if (!_board.IsInBoardY(y + j)) continue;
                
                var cell = _board.Cells[x, y + j];

                if (cell.HasItem())
                {
                    explodingCells.Add(cell);
                }
            }
        }
        else
        {
            Debug.LogError("RocketItem: Wrong ItemType");
        }

        return explodingCells;
    }

    public override SpecialType GetSpecialType()
    {
        return SpecialType.Rocket;
    }
}