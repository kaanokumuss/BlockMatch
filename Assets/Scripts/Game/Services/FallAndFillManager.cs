using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using Zenject;

namespace Game.Services
{
    public class FallAndFillManager : MonoBehaviour
    {
        [Inject] private Board _board;
        [Inject] private ItemFactory _itemFactory;
        private List<Cell> _fillingCells;
        private LevelData _levelData;
        private bool _isActive;

        private void Update()
        {
            if (_isActive)
            {
                DoFalls();
                DoFills();
            }
        }

        public void Prepare(LevelData levelData) 
        {
            Assert.IsNotNull(levelData, "Level data is null!");
            
            _levelData = levelData;
            CreateFillingCells();
        }

        public void StartFall()
        {
            _isActive = true;
        }

        private void CreateFillingCells() 
        {
            _fillingCells = new List<Cell>();

            for (int x = 0; x < _board.Rows; x++)
            {
                for (int y = 0; y < _board.Cols; y++)
                {
                    if (_board.Cells[x, y] != null && _board.Cells[x, y].IsFillingCell)
                    {
                        _fillingCells.Add(_board.Cells[x, y]);
                    }
                }
            }
            
            Assert.IsNotNull(_fillingCells, "Filling cells are null!");
            Assert.IsTrue(_fillingCells.Count > 0, "Filling cells count is 0!");
        }

        private void DoFalls()
        {
            Assert.IsNotNull(_board, "Board is null!");
            
            for (int x = 0; x < _board.Rows; x++)
            {
                for (int y = 0; y < _board.Cols; y++)
                {
                    if (IsValid(x, y))
                    {
                        _board.Cells[x, y].Item.Fall();
                    }
                }
            }
        }

        private void DoFills()
        {
            Assert.IsNotNull(_itemFactory, "Item factory is null!");
            
            foreach (var cell in _fillingCells)
            {
                if (cell.Item != null) continue;

                cell.Item = _itemFactory.Create(_levelData.GetNextFillItemType());
                
                var offsetY = .0f;
                var targetCellBelow = cell.GetFallTarget().FirstCellBelow;
                if (targetCellBelow != null && targetCellBelow.HasItem())
                {
                    offsetY = targetCellBelow.Item.transform.position.y + 1;
                }

                var position = cell.transform.position;
                position.y += 2;
                position.y = position.y > offsetY ? position.y : offsetY;

                if (!cell.HasItem()) continue;
                
                cell.Item.transform.position = position;
                cell.Item.Fall();
            }
        }

        private bool IsValid(int x, int y)
        {
            var cell = _board.Cells[x, y];
            return cell.Item != null 
                   && cell.FirstCellBelow != null
                   && cell.FirstCellBelow.Item == null;
        }
    }
}