using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ItemBase : MonoBehaviour
{
    public class ItemBaseFactory : PlaceholderFactory<ItemBase> {}

}
