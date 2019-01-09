using System;
// you can also use other imports, for example:
// using System.Collections.Generic;

// you can write to stdout for debugging purposes, e.g.
// Console.WriteLine("this is a debug message");

class Solution
{
    public int[] solution(int[] a, int[] b)
    {

        int[] result = new int[a.Length];

        int n = getMax(a);
        int p = getMax(b);

        int[] cache = buildCache(n, p);

        for (int i = 0; i < a.Length; i++)
        {
            result[i] = cache[a[i]] % (int)Math.Pow(2, b[i]);
        }

        return result;
    }

    private static int getMax(int[] array)
    {
        int max = array[0];

        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] > max)
            {
                max = array[i];
            }
        }

        return max;
    }

    public static int[] buildCache(int n, int p)
    {
        int[] cache = new int[n + 1];
        int previous = 1;
        int current = 1;

        cache[0] = 1;
        cache[1] = 1;

        int index = 3;

        while (index <= n + 1)
        {
            int temp = current;
            current = (previous + current) % (int)Math.Pow(2, p);
            previous = temp;

            cache[index - 1] = current;

            index++;
        }

        return cache;
    }
}