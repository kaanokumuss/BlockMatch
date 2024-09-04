public class Level_CrateTest : LevelData
{
    private ItemType[] _itemArray =
    {
        ItemType.GreenCube,
        ItemType.YellowCube,
        ItemType.BlueCube,
        ItemType.Balloon
    };
    
    public override void Initialize()
    {
        RowCount = 9;
        ColCount = 9;

        GridData = new ItemType[RowCount, ColCount];
        
        GridData[1, 1] = ItemType.Crate;
        GridData[1, 7] = ItemType.Crate;
        
        GridData[7, 1] = ItemType.Crate;
        GridData[7, 7] = ItemType.Crate;
        
        GridData[4, 3] = ItemType.Crate;
        GridData[4, 4] = ItemType.Crate;
        GridData[4, 5] = ItemType.Crate;
        
        GridData[2, 2] = ItemType.BlueBalloon;
        GridData[8, 8] = ItemType.BlueBalloon;

        for (int x = 0; x < RowCount; x++)
        {
            for (int y = 0; y < ColCount; y++)
            {
                if (GridData[x, y] != ItemType.None) continue;
                
                GridData[x, y] = GetRandomItemType();
            }
        }
    }

    public override ItemType GetNextFillItemType()
    {
        return GetRandomItemTypeFromArray(_itemArray);
    }
}