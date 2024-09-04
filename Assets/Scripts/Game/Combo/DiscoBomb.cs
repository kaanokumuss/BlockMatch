using System.Collections.Generic;
using Zenject;

namespace Game.Combo
{
    public class DiscoBomb : Combo
    {
        [Inject] private Board _board;
        [Inject] private ItemFactory _itemFactory;
        private const int MaxAmount = 4;
        
        public DiscoBomb(Cell tappedCell, List<Cell> comboCells) : base(tappedCell, comboCells)
        {
            TappedCell = tappedCell;
            comboCells = comboCells;
        }

        protected override List<Cell> GetExplodingCells()
        {
            var explodingCells = new List<Cell>();
        
            var x = TappedCell.X;
            var y = TappedCell.Y;
        
            var cell = (Cell[,])_board.Cells.Clone(); 
            cell.Shuffle();

            for (int i = 0; i < _board.Rows; i++)
            {
                for (int j = 0; j < _board.Cols; j++)
                {
                    if (IsValid(cell[i, j], explodingCells.Count))
                    {
                        explodingCells.Add(cell[i, j]);
                        cell[i, j].Item.TryExecute();
                        var item = _itemFactory.Create(ItemType.Bomb);
                        cell[i, j].Item = item;
                        item.transform.position = cell[i, j].transform.position;
                    }

                    if (explodingCells.Count >= MaxAmount)
                    {
                        break;
                    }
                }
            }

            if (!explodingCells.Contains(TappedCell))
            {
                explodingCells.Add(TappedCell);
            }
        
            return explodingCells;
        }
        
        private bool IsValid(Cell cell, int explodingCellsCount)
        {
            return cell.HasItem() && cell.Item.GetItemType() == ItemType.None && explodingCellsCount <= MaxAmount;
        }
    }
}