using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "GameplayInstaller", menuName = "Installers/GameplayInstaller")]
public class GameplayInstaller : ScriptableObjectInstaller<GameplayInstaller>
{
    [SerializeField] private Cell cellPrefab;
    [SerializeField] private ItemBase itemBasePrefab;
    [SerializeField] Item itemPrefab;
    public override void InstallBindings()
    {
        SignalBusInstaller.Install(Container);
        Container.Bind<Board>().FromComponentInHierarchy().AsSingle();
        Container.BindFactory<Cell, Cell.CellFactory>().FromComponentInNewPrefab(cellPrefab).AsSingle();
        Container.BindFactory<ItemBase, ItemBase.ItemBaseFactory>().FromComponentInNewPrefab(itemBasePrefab).AsSingle();
        Container.BindFactory<Item, Item.Factory>().FromComponentInNewPrefab(itemPrefab).AsSingle();

        Container.DeclareSignal<OnElementTappedSignal>();
        Container.DeclareSignal<OnEmptyTappedSignal>();
    }
}