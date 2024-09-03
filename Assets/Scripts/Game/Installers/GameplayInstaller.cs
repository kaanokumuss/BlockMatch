using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "GameplayInstaller", menuName = "Installers/GameplayInstaller")]
public class GameplayInstaller : ScriptableObjectInstaller<GameplayInstaller>
{
    [SerializeField] private Cell cellPrefab;
    public override void InstallBindings()
    {
        Container.BindFactory<Cell, Cell.CellFactory>().FromComponentInNewPrefab(cellPrefab).AsSingle();
    }
}