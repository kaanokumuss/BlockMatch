using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "GameplayInstaller", menuName = "Installers/GameplayInstaller")]
public class GameplayInstaller : ScriptableObjectInstaller<GameplayInstaller>
{
    [SerializeField] private Cell cellPrefab;
    [SerializeField] private ItemBase itemBasePrefab;
    public override void InstallBindings()
    {
        Container.BindFactory<Cell, Cell.CellFactory>().FromComponentInNewPrefab(cellPrefab).AsSingle();
        Container.BindFactory<ItemBase, ItemBase.ItemBaseFactory>().FromComponentInNewPrefab(itemBasePrefab).AsSingle();
        Container.DeclareSignal<OnElementTappedSignal>();
        Container.DeclareSignal<OnEmptyTappedSignal>();
    }
}