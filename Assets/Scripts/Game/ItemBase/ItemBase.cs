using UnityEngine;
using Zenject;

public class ItemBase : MonoBehaviour
{
    [SerializeField] private FallAnimation fallAnimation;
    public FallAnimation FallAnimation => fallAnimation;
    
    public class Factory : PlaceholderFactory<ItemBase> { }
}
