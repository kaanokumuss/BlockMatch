using System;
using UnityEngine;
using Zenject;

public class ColorBalloonItem : Item
{
    [Inject] private ImageLibService _imageLibService;
    private MatchType _matchType;
    
    public void PrepareColorBalloonItem(ItemBase itemBase, MatchType matchType, ItemType itemType)
    {
        ItemType = itemType;
        _matchType = matchType;
        var sprite = GetDefaultItemSprite();
        Prepare(itemBase, sprite);
    }
    
    public override void TryExecuteByNearMatch(MatchType matchType)
    {
        if (matchType == _matchType)
        {
            TryExecute();
        }
    }

    protected override Sprite GetDefaultItemSprite()
    {
        switch (_matchType)
        {
            case MatchType.None:
                Debug.LogWarning("MatchType is None");
                break;
            case MatchType.Green:
                return _imageLibService.Images.balloonGreen;
            case MatchType.Yellow:
                return _imageLibService.Images.balloonYellow;
            case MatchType.Blue:
                return _imageLibService.Images.balloonBlue;
            case MatchType.Red:
                return _imageLibService.Images.balloonRed;
            case MatchType.Pink:
                return _imageLibService.Images.balloonPink;
            case MatchType.Purple:
                return _imageLibService.Images.balloonPurple;
            default:
                throw new ArgumentOutOfRangeException();
        }

        return null;
    }
}