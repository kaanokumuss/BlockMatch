using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class Borders : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private CinemachineTargetGroup targetGroup;
    private const float Offset = .4f;

    public void Prepare(int row, int col, List<Cell> cells)
    {
        spriteRenderer.size = new Vector2(row + Offset, col + Offset);
        targetGroup.m_Targets = new CinemachineTargetGroup.Target[cells.Count];
        for (var i = 0; i < cells.Count; i++)
        {
            targetGroup.m_Targets[i].target = cells[i].transform;
            targetGroup.m_Targets[i].weight = 1;
        }
    }
}