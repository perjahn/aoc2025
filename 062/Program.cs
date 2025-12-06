using System;
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
        rows = Rotate(rows);

        long total = 0;
        long sum = 0;
        var op = ' ';

        for (var i = 0; i < rows.Length; i++)
        {
            if (string.IsNullOrWhiteSpace(rows[i]))
            {
                continue;
            }
            else if (rows[i][^1] is '*' or '+')
            {
                op = rows[i][^1];
                sum = long.Parse(rows[i][..^1]);
            }
            else
            {
                if (op == '*')
                {
                    sum *= long.Parse(rows[i]);
                }
                else if (op == '+')
                {
                    sum += long.Parse(rows[i]);
                }
            }

            if (i == rows.Length - 1 || string.IsNullOrWhiteSpace(rows[i + 1]))
            {
                total += sum;
                sum = 0;
            }
        }

        return total;
    }

    static string[] Rotate(string[] rows)
    {
        var rotated = new string[rows[0].Length];

        for (var i = 0; i < rows[0].Length; i++)
        {
            rotated[i] = string.Join(string.Empty, rows.Select(r => r[i]));
        }

        return rotated;
    }
}
