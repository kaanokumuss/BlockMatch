using System;
using UnityEngine;
using Zenject;

public class CrateItem : Item
{
    [Inject] private ImageLibService _imageLibService;
    private int _layerCount = 2;

    public void PrepareCrateItem(ItemBase itemBase, int layerCount, ItemType itemType)
    {
        ItemType = itemType;
        _layerCount = layerCount;
        var sprite = GetDefaultItemSprite();
        Prepare(itemBase, sprite);
        CanFall = false;
    }

    protected override Sprite GetDefaultItemSprite()
    {
        return _layerCount switch
        {
            1 => _imageLibService.Images.createLayer1,
            2 => _imageLibService.Images.createLayer2,
            _ => null
        };
    }

    public override void TryExecuteByNearMatch(MatchType matchType)
    {
        TryExecute();
    }

    public override void TryExecute()
    {
        _layerCount--;

        switch (_layerCount)
        {
            case 0:
                base.TryExecute();
                break;
            case 1:
                ChangeSprite(GetDefaultItemSprite());
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}