using System;
using System.Collections.Generic;
using System.Linq;

public static class ListExtensions{
    private static Random rng = new Random();

    public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> enumerable)  
    {  
        var list = enumerable.ToArray();
        int n = list.Length;
        while (n > 1) {  
            n--;  
            int k = rng.Next(n + 1);  
            T value = list[k];  
            list[k] = list[n];  
            list[n] = value;
        }  

        return list;
    }
}