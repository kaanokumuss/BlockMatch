using UnityEngine;
using Zenject;

public class Board : MonoBehaviour
{
    [Inject] private Cell.CellFactory _cellFactory;
}
