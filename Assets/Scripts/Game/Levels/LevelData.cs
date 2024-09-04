public abstract class LevelData
{
    public abstract void Initialize();
    public abstract ItemType GetNextFillItemType();
    public ItemType[,] GridData { get; protected set; }
    public int ColCount;
    public int RowCount;

    protected ItemType[] DefaultItemTypes = new[]
    {
        ItemType.GreenCube,
        ItemType.YellowCube,
        ItemType.BlueCube,
        ItemType.RedCube,
        ItemType.PinkCube,
        ItemType.PurpleCube
    };

    protected ItemType GetRandomItemType()
    {
         return GetRandomItemTypeFromArray(DefaultItemTypes);
    } 
    protected ItemType GetRandomItemTypeFromArray(ItemType[] itemTypes)
    {
        return itemTypes[UnityEngine.Random.Range(0, itemTypes.Length)];
    }
}