using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main()
    {
        var rows = File.ReadAllLines("input.txt");

        var count = GetFresh(rows);

        Console.WriteLine(count);
    }

    static int GetFresh(string[] rows)
    {
        int rownum;

        List<(long, long)> ranges = [];
        for (rownum = 0; rownum < rows.Length && rows[rownum] != string.Empty; rownum++)
        {
            var parts = rows[rownum].Split('-');
            ranges.Add((long.Parse(parts[0]), long.Parse(parts[1])));
        }

        rownum++;

        var count = 0;

        for (; rownum < rows.Length; rownum++)
        {
            var num = long.Parse(rows[rownum]);

            var isFresh = false;
            foreach (var (start, end) in ranges)
            {
                if (num >= start && num <= end)
                {
                    isFresh = true;
                    break;
                }
            }

            if (isFresh)
            {
                count++;
            }
        }

        return count;
    }
}
