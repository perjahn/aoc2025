using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main()
    {
        var rows = File.ReadAllLines("input.txt");

        List<int> rotations = [];

        foreach (var row in rows)
        {
            if (row[0] == 'L')
            {
                rotations.Add(-int.Parse(row[1..]));
            }
            if (row[0] == 'R')
            {
                rotations.Add(int.Parse(row[1..]));
            }
        }

        var result = 0;
        var currentpos = 50;

        foreach (var rotation in rotations)
        {
            currentpos += rotation;
            currentpos %= 100;
            if (currentpos == 0)
            {
                result++;
            }
        }

        Console.WriteLine(result);
    }
}
