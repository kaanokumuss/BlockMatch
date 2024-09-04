using System.Collections.Generic;
using UnityEngine;

public static class UnityHelpers
{
    public static T GetRandomWithLuck<T>(this List<T> values, List<float> lucks)
    {
        var index = GetItemByLuck(lucks);
        return values[index];
    }

    private static int GetItemByLuck(List<float> lucks)
    {
        float total = 0;
        foreach (var item in lucks)
        {
            total += item;
        }

        var randomPoint = Random.value * total;

        for (int i = 0; i < lucks.Count; i++)
        {
            if (randomPoint < lucks[i])
            {
                return i;
            }

            randomPoint -= lucks[i];
        }

        return lucks.Count - 1;
    } 
}