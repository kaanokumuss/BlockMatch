using Game.ItemBase;
using UnityEngine;
using Zenject;

public class FallAnimation : MonoBehaviour
{
    [Inject] ItemStatsSO _itemStatsSO;

    [HideInInspector] public Item Item;
    [HideInInspector] public Cell TargetCell;
    public bool IsFalling { get; private set; }
    
    private float _currVel;
    private Vector3 _targetPos;

    private void Awake()
    {
        _currVel = _itemStatsSO.startVel;
    }

    public void FallTo(Cell targetCell)
    {
        if (TargetCell != null && targetCell.Y >= TargetCell.Y) return;
        
        TargetCell = targetCell;
        Item.Cell = TargetCell;
        _targetPos = TargetCell.transform.position;
        IsFalling = true;
    }

    private void Update()
    {
        if (!IsFalling) return;

        _currVel += _itemStatsSO.acc;
        _currVel = _currVel >= _itemStatsSO.maxSpeed ? _itemStatsSO.maxSpeed : _currVel;

        var position = this.Item.transform.position;
        position.y -= _currVel * Time.deltaTime;
        
        if (position.y <= _targetPos.y)
        {
            IsFalling = false;
            TargetCell = null;
            position.y = _targetPos.y;
            _currVel = _itemStatsSO.startVel;
        }
        
        this.Item.transform.position = position;

    }
}
