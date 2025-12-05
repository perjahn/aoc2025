using System;
using System.IO;

class Program
{
    static void Main()
    {
        var rows = File.ReadAllLines("input.txt");

        var count = CountAllFreeRolls(rows);

        Console.WriteLine(count);
    }

    static int CountAllFreeRolls(string[] rows)
    {
        var sum = 0;
        int count;

        do
        {
            count = CountFreeRolls(rows);
            sum += count;
        }
        while (count > 0);

        return sum;
    }

    static int CountFreeRolls(string[] rows)
    {
        var count = 0;

        for (var i = 0; i < rows.Length; i++)
        {
            for (var j = 0; j < rows[i].Length; j++)
            {
                var atcount = 0;
                char c = '@';

                if (rows[i][j] != c)
                {
                    continue;
                }

                if (i > 0 && j > 0 && rows[i - 1][j - 1] == c)
                {
                    atcount++;
                }
                if (i > 0 && rows[i - 1][j] == c)
                {
                    atcount++;
                }
                if (i > 0 && j < rows[i - 1].Length - 1 && rows[i - 1][j + 1] == c)
                {
                    atcount++;
                }
                if (j > 0 && rows[i][j - 1] == c)
                {
                    atcount++;
                }
                if (j < rows[i].Length - 1 && rows[i][j + 1] == c)
                {
                    atcount++;
                }
                if (i < rows.Length - 1 && j > 0 && rows[i + 1][j - 1] == c)
                {
                    atcount++;
                }
                if (i < rows.Length - 1 && rows[i + 1][j] == c)
                {
                    atcount++;
                }
                if (i < rows.Length - 1 && j < rows[i + 1].Length - 1 && rows[i + 1][j + 1] == c)
                {
                    atcount++;
                }

                if (atcount < 4)
                {
                    rows[i] = $"{rows[i][..j]}x{rows[i][(j + 1)..]}";
                    count++;
                }
            }
        }

        return count;
    }
}
