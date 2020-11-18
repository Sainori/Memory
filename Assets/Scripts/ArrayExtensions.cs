using System;

public static class ArrayExtensions
{
    private static Random Random = new Random();

    public static void Shuffle<T> (this T[] array)
    {
        int n = array.Length;
        while (n > 1) 
        {
            n--;
            int k = Random.Next(n + 1);
            T temp = array[n];
            array[n] = array[k];
            array[k] = temp;
        }
    }
}