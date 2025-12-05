using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Program
{
    static void Main()
    {
        var rows = File.ReadAllLines("input.txt");

        var count = GetFresh(rows);

        Console.WriteLine(count);
    }

    static long GetFresh(string[] rows)
    {
        List<(long start, long end)> ranges = [];

        for (var i = 0; i < rows.Length && rows[i] != string.Empty; i++)
        {
            var parts = rows[i].Split('-');
            ranges.Add((long.Parse(parts[0]), long.Parse(parts[1])));
        }

        ranges = [.. ranges.OrderBy(r => r.start).ThenBy(r => r.end)];

        for (var i = 0; i < ranges.Count - 1;)
        {
            var start1 = ranges[i].start;
            var end1 = ranges[i].end;
            var start2 = ranges[i + 1].start;
            var end2 = ranges[i + 1].end;

            if (Math.Max(start1, start2) <= Math.Min(end1, end2))
            {
                ranges[i] = (Math.Min(start1, start2), Math.Max(end1, end2));
                ranges.RemoveAt(i + 1);
            }
            else
            {
                i++;
            }
        }

        long idcount = 0;

        foreach (var (start, end) in ranges)
        {
            idcount += end - start + 1;
        }

        return idcount;
    }
}
