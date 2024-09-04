using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class UnityHelpers
{
    public static T GetRandom<T>(this List<T> values)
    {
        return values.ElementAt(Random.Range(0, values.Count));
    }
    
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
    
    public static void Shuffle<T>(this T[,] array)
    {
        var lengthRow = array.GetLength(1);

        for (int i = array.Length -1; i > 0 ; i--)
        {
            var i0 = i / lengthRow;
            var i1 = i % lengthRow;
            
            var j = Random.Range(0, i + 1);
            var j0 = j / lengthRow;
            var j1 = j % lengthRow;
            
            (array[i0, i1], array[j0, j1]) = (array[j0, j1], array[i0, i1]);
        }
    }
}