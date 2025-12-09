using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Program
{
    static void Main()
    {
        var rows = File.ReadAllLines("input.txt");

        var result = GetCircuits(rows);

        Console.WriteLine(result);
    }

    static long GetCircuits(string[] rows)
    {
        int[][] coords = [.. rows.Select(r => r.Split(',').Select(int.Parse).ToArray())];

        List<(int x1, int y1, int z1, int x2, int y2, int z2, double distance)> distances = [];

        for (var i = 0; i < coords.Length; i++)
        {
            for (var j = i + 1; j < coords.Length; j++)
            {
                long dx = Math.Abs(coords[i][0] - coords[j][0]);
                long dy = Math.Abs(coords[i][1] - coords[j][1]);
                long dz = Math.Abs(coords[i][2] - coords[j][2]);
                double distance = Math.Sqrt((dx * dx) + (dy * dy) + (dz * dz));
                distances.Add((coords[i][0], coords[i][1], coords[i][2], coords[j][0], coords[j][1], coords[j][2], distance));
            }
        }

        List<List<(int x, int y, int z)>> circuits = [.. coords
            .Select(c => new List<(int x, int y, int z)> { (c[0], c[1], c[2]) })];

        (int x1, int y1, int z1, int x2, int y2, int z2, double distance)[] shortest = [.. distances
            .OrderBy(d => d.distance)];

        (int x1, int y1, int z1, int x2, int y2, int z2) lastmerge = (-1, -1, -1, -1, -1, -1);

        for (var shortestIndex = 0; circuits.Count > 1; shortestIndex++)
        {
            if (shortestIndex >= shortest.Length)
            {
                Console.WriteLine("Error: Out of distances");
                break;
            }

            var (x1, y1, z1, x2, y2, z2, distance) = shortest[shortestIndex];

            if (circuits.Any(c => c.Any(j => j == (x1, y1, z1)) && c.Any(j => j == (x2, y2, z2))))
            {
                continue;
            }

            List<List<(int x, int y, int z)>> found = [.. circuits.Where(c => c.Any(j => j == (x1, y1, z1)) || c.Any(j => j == (x2, y2, z2)))];

            found[0].AddRange(found[1]);
            _ = circuits.Remove(found[1]);

            lastmerge = (x1, y1, z1, x2, y2, z2);
        }

        return ((long)lastmerge.x1) * lastmerge.x2;
    }
}
