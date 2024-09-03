using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Item : MonoBehaviour
{
    public class ItemFactory : PlaceholderFactory<Item> {}
}
