using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;

class Program
{
    static void Main()
    {
        var rows = File.ReadAllLines("input.txt");

        var result = GetArea(rows);

        Console.WriteLine(result);
    }

    static long GetArea(string[] rows)
    {
        int[][] coords = [.. rows.Select(r => r.Split(',').Select(int.Parse).ToArray())];

        List<(int c1, int c2, long area)> areas = [];

        for (var c1 = 0; c1 < coords.Length; c1++)
        {
            for (var c2 = c1 + 1; c2 < coords.Length; c2++)
            {
                if ((coords[c1][1] < 50000 && coords[c2][1] > 50000) || (coords[c1][1] > 50000 && coords[c2][1] < 50000))
                {
                    continue;
                }

                for (var i = 0; i < coords.Length; i++)
                {
                    if (i == c1 || i == c2)
                    {
                        continue;
                    }

                    if (coords[i][0] > Math.Min(coords[c1][0], coords[c2][0]) &&
                        coords[i][0] < Math.Max(coords[c1][0], coords[c2][0]) &&
                        coords[i][1] > Math.Min(coords[c1][1], coords[c2][1]) &&
                        coords[i][1] < Math.Max(coords[c1][1], coords[c2][1]))
                    {
                        break;
                    }

                    if (i == coords.Length - 1)
                    {
                        int dx = Math.Abs(coords[c1][0] - coords[c2][0]) + 1;
                        int dy = Math.Abs(coords[c1][1] - coords[c2][1]) + 1;
                        long area = ((long)dx) * dy;
                        areas.Add((c1, c2, area));
                    }
                }
            }
        }

        return areas.OrderByDescending(a => a.area).Take(1).Single().area;
    }
}
