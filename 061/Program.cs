using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Program
{
    static void Main()
    {
        var rows = File.ReadAllLines("input.txt");

        var total = GetTotal(rows);

        Console.WriteLine(total);
    }

    static long GetTotal(string[] rows)
    {
        List<long[]> values = [];

        for (var i = 0; i < rows.Length - 1; i++)
        {
            long[] nums = [.. rows[i]
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(long.Parse)];

            values.Add(nums);
        }

        char[] operators = [.. rows[^1]
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select( o => o[0])];

        long total = 0;

        for (var i = 0; i < values[0].Length; i++)
        {
            long colsum = values[0][i];

            for (var j = 1; j < values.Count; j++)
            {
                switch (operators[i])
                {
                    case '+':
                        colsum += values[j][i];
                        break;
                    case '*':
                        colsum *= values[j][i];
                        break;
                    default:
                        Console.WriteLine("Unknown operator");
                        break;
                }
            }

            total += colsum;
        }

        return total;
    }
}
