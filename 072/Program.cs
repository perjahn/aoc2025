using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main()
    {
        var rows = File.ReadAllLines("input.txt");

        var splits = GetTotalSplits(rows);

        Console.WriteLine(splits);
    }

    static long GetTotalSplits(string[] rows)
    {
        long splits = 0;

        for (var i = 0; i < rows[0].Length; i++)
        {
            if (rows[0][i] == 'S')
            {
                splits += GetSplits(rows, i, 0);
            }
        }

        return splits;
    }

    static readonly Dictionary<(int x, int y), long> memoization = [];

    static long GetSplits(string[] rows, int x, int y)
    {
        if (memoization.TryGetValue((x, y), out var timelines))
        {
            return timelines;
        }

        if (y == rows.Length - 1)
        {
            memoization[(x, y)] = 1;
            return 1;
        }

        if (rows[y + 1][x] == '.')
        {
            var splits = GetSplits(rows, x, y + 1);
            memoization[(x, y)] = splits;
            return splits;
        }

        if (rows[y + 1][x] == '^')
        {
            var splits = GetSplits(rows, x - 1, y + 1) + GetSplits(rows, x + 1, y + 1);
            memoization[(x, y)] = splits;
            return splits;
        }

        Console.WriteLine($"Unexpected character ({x},{y + 1}): '{rows[y + 1][x]}'");
        memoization[(x, y)] = 1;
        return 1;
    }
}
