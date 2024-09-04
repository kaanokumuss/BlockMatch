using System;
using UnityEngine;
using UnityEngine.Assertions;
using Zenject;

public class ItemFactory : MonoBehaviour
{
    [Inject] private ItemBase.Factory _itemBaseFactory;
    [Inject] private DiContainer _diContainer;

    public Item Create(ItemType itemType, int layerCount = 2, ItemType itemTypeCliked = ItemType.None)
    {
        Assert.IsNotNull(_itemBaseFactory, "_itemBaseFactory is null");
        
        var itemBase = _itemBaseFactory.Create();
        Item item = null;
        switch (itemType)
        {
            case ItemType.None:
                break;
            case ItemType.GreenCube:
                item = CreateCubeItem(itemBase, MatchType.Green, itemType);
                break;
            case ItemType.YellowCube:
                item = CreateCubeItem(itemBase, MatchType.Yellow, itemType);
                break;
            case ItemType.BlueCube:
                item = CreateCubeItem(itemBase, MatchType.Blue, itemType);
                break;
            case ItemType.RedCube:
                item = CreateCubeItem(itemBase, MatchType.Red, itemType);
                break;
            case ItemType.PinkCube:
                item = CreateCubeItem(itemBase, MatchType.Pink, itemType);
                break;
            case ItemType.PurpleCube:
                item = CreateCubeItem(itemBase, MatchType.Purple, itemType);
                break;
            case ItemType.Balloon:
                item = CreateBalloonItem(itemBase, itemType);
                break;
            case ItemType.GreenBalloon:
                item = CreateColorBalloonItem(itemBase, MatchType.Green, itemType);
                break;
            case ItemType.YellowBalloon:
                item = CreateColorBalloonItem(itemBase, MatchType.Yellow, itemType);
                break;
            case ItemType.BlueBalloon:
                item = CreateColorBalloonItem(itemBase, MatchType.Blue, itemType);
                break;
            case ItemType.RedBalloon:
                item = CreateColorBalloonItem(itemBase, MatchType.Red, itemType);
                break;
            case ItemType.PinkBalloon:
                item = CreateColorBalloonItem(itemBase, MatchType.Pink, itemType);
                break;
            case ItemType.PurpleBalloon:
                item = CreateColorBalloonItem(itemBase, MatchType.Purple, itemType);
                break;
            case ItemType.Crate:
                item = CreateCrateItem(itemBase, layerCount, itemType);
                break;
            case ItemType.Bomb:
                item = CreateBombItem(itemBase, itemType);
                break;
            case ItemType.VerticalRocket:
                item = CreateRocketItem(itemBase, itemType);
                break;
            case ItemType.HorizontalRocket:
                item = CreateRocketItem(itemBase, itemType);
                break;
            case ItemType.Disco:
                item = CreateDiscoItem(itemBase, itemType, itemTypeCliked);
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(itemType), itemType, null);
        }

        return item;
    }

    private Item CreateColorBalloonItem(ItemBase itemBase, MatchType matchType, ItemType itemType)
    {
        var colorBalloonItem = itemBase.gameObject.AddComponent<ColorBalloonItem>();
        _diContainer.Inject(colorBalloonItem);
        colorBalloonItem.PrepareColorBalloonItem(itemBase, matchType, itemType);

        return colorBalloonItem;
    }

    private Item CreateBalloonItem(ItemBase itemBase, ItemType itemType)
    {
        var balloonItem = itemBase.gameObject.AddComponent<BalloonItem>();
        _diContainer.Inject(balloonItem);
        balloonItem.PrepareBalloonItem(itemBase, itemType);

        return balloonItem;
    }

    private Item CreateCrateItem(ItemBase itemBase, int layerCount, ItemType itemType)
    {
        var crateItem = itemBase.gameObject.AddComponent<CrateItem>();
        _diContainer.Inject(crateItem);
        crateItem.PrepareCrateItem(itemBase, layerCount, itemType);

        return crateItem;
    }

    private Item CreateDiscoItem(ItemBase itemBase, ItemType itemType, ItemType itemTypeCliked)
    {
        var discoItem = itemBase.gameObject.AddComponent<DiscoItem>();
        _diContainer.Inject(discoItem);
        discoItem.PrepareDiscoItem(itemBase, itemType, itemTypeCliked);

        return discoItem;
    }

    private Item CreateBombItem(ItemBase itemBase, ItemType itemType)
    {
        var bombItem = itemBase.gameObject.AddComponent<BombItem>();
        _diContainer.Inject(bombItem);
        bombItem.PrepareBombItem(itemBase, itemType);

        return bombItem;
    }

    private Item CreateRocketItem(ItemBase itemBase, ItemType itemType)
    {
        var rocketItem = itemBase.gameObject.AddComponent<RocketItem>();
        _diContainer.Inject(rocketItem);
        rocketItem.PrepareRocketItem(itemBase, itemType);

        return rocketItem;
    }

    private Item CreateCubeItem(ItemBase itemBase, MatchType matchType, ItemType itemType)
    {
        var cubeItem = itemBase.gameObject.AddComponent<CubeItem>();
        _diContainer.Inject(cubeItem);
        cubeItem.PrepareCubeItem(itemBase, matchType, itemType);

        return cubeItem;
    }
}
