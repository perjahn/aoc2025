using System;
using System.Collections.Generic;
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

        List<(int x1, int y1, int x2, int y2, long area)> areas = [];

        for (var i = 0; i < coords.Length; i++)
        {
            for (var j = i + 1; j < coords.Length; j++)
            {
                int dx = Math.Abs(coords[i][0] - coords[j][0]) + 1;
                int dy = Math.Abs(coords[i][1] - coords[j][1]) + 1;
                long area = ((long)dx) * dy;
                areas.Add((coords[i][0], coords[i][1], coords[j][0], coords[j][1], area));
            }
        }

        var largest = areas.OrderByDescending(a => a.area).First();

        return largest.area;
    }
}
