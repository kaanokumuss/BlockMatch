public class Level_1 : LevelData
{
    public override void Initialize()
    {
        RowCount = 10;
        ColCount = 12;

        GridData = new ItemType[RowCount, ColCount];

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
        return GetRandomItemType();
    }
}