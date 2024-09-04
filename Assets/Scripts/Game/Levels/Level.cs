using Game.Services;
using UnityEngine;
using Zenject;

public enum LevelName
{
    Level_1,
    Level_2,
    Level_CrateTest
}

public class Level : MonoBehaviour
{
    [SerializeField] private LevelName levelName;
    [Inject] private FallAndFillManager _fallAndFillManager;
    private ItemFactory  _itemFactory;
    private Board _board;
    private LevelData _currentLevelData;
    
    [Inject]
    public void Initialize(Board board, ItemFactory itemFactory)
    {
        _itemFactory = itemFactory;
        _board = board;
    }

    private void Start()
    {
        GetLevelData();
        PrepareBoard();
        PrepareLevel();
        StartFalls();
    }

    private void GetLevelData()
    {
        _currentLevelData = LevelDataFactory.Create(levelName);
    }
    
    private void PrepareBoard()
    {
        _board.Prepare(_currentLevelData.RowCount, _currentLevelData.ColCount);
    }

    private void PrepareLevel()
    {
        for (int x = 0; x < _currentLevelData.GridData.GetLength(0); x++)
        {
            for (int y = 0; y < _currentLevelData.GridData.GetLength(1); y++)
            {
                var cell = _board.Cells[x, y];
                var itemType = _currentLevelData.GridData[x, y];
                var item = _itemFactory.Create(itemType);

                if (item == null) continue;

                cell.Item = item;
                item.transform.position = cell.transform.position;
            }
        }
    }

    private void StartFalls()
    {
        _fallAndFillManager.Prepare(_currentLevelData);
        _fallAndFillManager.StartFall();
    }
}