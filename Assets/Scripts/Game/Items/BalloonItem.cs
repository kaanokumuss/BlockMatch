using UnityEngine;
using Zenject;

public class BalloonItem : Item
{
    [Inject] private ImageLibService _imageLibService;
    
    public void PrepareBalloonItem(ItemBase itemBase, ItemType itemType)
    {
        ItemType = itemType;
        var sprite = GetDefaultItemSprite();
        Prepare(itemBase, sprite);
    }

    protected override Sprite GetDefaultItemSprite()
    {
        return _imageLibService.Images.balloon;
    }

    public override void TryExecuteByNearMatch(MatchType matchType)
    {
        TryExecute();
    }
}