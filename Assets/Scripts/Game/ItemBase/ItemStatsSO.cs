using UnityEngine;

namespace Game.ItemBase
{
    [CreateAssetMenu(fileName = "NewItemStat", menuName = "Scriptable Objects/ItemStat")]
    public class ItemStatsSO : ScriptableObject
    {
        public float startVel = .0f;
        public float acc = .4f;
        public float maxSpeed = 20f;
    }
}