using System.Collections.Generic;
using Game.Combo;
using Zenject;

public class RocketRocketCombo : Combo
{
    [Inject] private Board _board;
    
    public RocketRocketCombo(Cell tappedCell, List<Cell> comboCells) : base(tappedCell, comboCells)
    {
        TappedCell = tappedCell;
        comboCells = comboCells;
    }

    protected override List<Cell> GetExplodingCells()
    {
        var explodingCells = new List<Cell>();
        
        var x = TappedCell.X;
        var y = TappedCell.X;

        for (int i = -_board.Rows; i < _board.Rows; i++)
        {
            if (!_board.IsInBoardX(x + i)) continue;

            var cell = _board.Cells[x + i, y];
            if (cell.HasItem())
            {
                explodingCells.Add(cell);
            }
        }
        
        for (int j = -_board.Cols; j < _board.Cols; j++)
        {
            if (!_board.IsInBoardY(y + j)) continue;

            var cell = _board.Cells[x, y + j];
            if (cell.HasItem())
            {
                explodingCells.Add(cell);
            }
        }

        return explodingCells;
    }
}