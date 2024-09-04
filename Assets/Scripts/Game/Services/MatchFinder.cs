using System.Collections.Generic;

namespace Game.Services
{
    public class MatchFinder
    {
        private bool[,] _visitedCells;

        public MatchFinder(int rowCount, int colCount)
        {
            _visitedCells = new bool[rowCount, colCount];
        }

        public List<Cell> FindMatches(Cell cell, MatchType matchType)
        {
            var resultCells = new List<Cell>();
            ClearVisitedCells();
            FindMatchesRecursive(cell, matchType, resultCells);
            return resultCells;
        }

        private void FindMatchesRecursive(Cell cell, MatchType matchType, List<Cell> resultCells)
        {
            if (cell == null) return;

            var x = cell.X;
            var y = cell.Y;

            if (_visitedCells[x, y]) return;
            if (!IsVisited(cell, matchType)) return;
            
            _visitedCells[x, y] = true;
            resultCells.Add(cell);
            
            var neighbours = cell.Neighbors;
            if (neighbours.Count == 0) return;

            for (var i = 0; i < neighbours.Count; i++)
            {
                FindMatchesRecursive(neighbours[i], matchType, resultCells);
            }
        }

        private bool IsVisited(Cell cell, MatchType matchType)
        {
            return cell.HasItem()
                && cell.Item.GetMatchType() == matchType
                && cell.Item.GetMatchType() != MatchType.None;
        }

        private void ClearVisitedCells()
        {
            for (var i = 0; i < _visitedCells.GetLength(0); i++)
            {
                for (var j = 0; j < _visitedCells.GetLength(1); j++)
                {
                    _visitedCells[i, j] = false;
                }
            }
        }
    }
}