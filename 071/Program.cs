using System;
using System.IO;
using System.Linq;

class Program
{
    static void Main()
    {
        var rows = File.ReadAllLines("input.txt");

        var splits = GetSplits(rows);

        Console.WriteLine(splits);
    }

    static long GetSplits(string[] rows)
    {
        char[][] charrows = [.. rows.Select(r => r.ToCharArray())];

        long splits = 0;

        for (var row = 0; row < charrows.Length - 1; row++)
        {
            for (var i = 0; i < charrows[row].Length; i++)
            {
                if (i < charrows.Length - 1 && charrows[row][i] is 'S' or '|')
                {
                    if (charrows[row + 1][i] == '^')
                    {
                        charrows[row + 1][i - 1] = '|';
                        charrows[row + 1][i + 1] = '|';
                        splits++;
                    }
                    if (charrows[row + 1][i] == '.')
                    {
                        charrows[row + 1][i] = '|';
                    }
                }
            }
        }

        return splits;
    }
}
