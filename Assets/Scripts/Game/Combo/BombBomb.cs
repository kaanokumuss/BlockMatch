using System.Collections.Generic;
using Zenject;

namespace Game.Combo
{
    public class BombBomb : Combo
    {
        [Inject] private Board _board;
        private const int ExplosionRange = 3;
    
        public BombBomb(Cell tappedCell, List<Cell> comboCells) : base(tappedCell, comboCells)
        {
            TappedCell = tappedCell;
            comboCells = comboCells;
        }

        protected override List<Cell> GetExplodingCells()
        {
            var explodingCells = new List<Cell>();
        
            var x = TappedCell.X;
            var y = TappedCell.Y;

            for (int i = -ExplosionRange; i <= ExplosionRange; i++)
            {
                for (int j = -ExplosionRange; j <= ExplosionRange; j++)
                {
                    if (!_board.IsInBoard(x + i, y + j)) continue;
                
                    var cell = _board.Cells[x + i, y + j];
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