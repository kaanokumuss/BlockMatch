using System.Collections.Generic;
using Game.Combo;
using Zenject;

namespace Game.Combo
{
    public class BombRocketCombo : Combo
    {
        [Inject] private Board _board;
        private const int ExplosionRange = 1;
    
        public BombRocketCombo(Cell tappedCell, List<Cell> comboCells) : base(tappedCell, comboCells)
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
                for (int k = -ExplosionRange; k < ExplosionRange; k++)
                {
                    if (!_board.IsInBoard(x + i, y + k)) continue;

                    var cell = _board.Cells[x + i, y + k];
                    if (cell.HasItem())
                    {
                        explodingCells.Add(cell);
                    }
                }
            }
        
            for (int j = -_board.Cols; j < _board.Cols; j++)
            {
                for (int k = -ExplosionRange; k < ExplosionRange; k++)
                {
                    if (!_board.IsInBoard(x + k, y + j)) continue;

                    var cell = _board.Cells[x + k, y + j];
                    if (cell.HasItem())
                    {
                        explodingCells.Add(cell);
                    }
                }
            }

            return explodingCells;
        }
    }
}