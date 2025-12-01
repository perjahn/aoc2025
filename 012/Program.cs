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
            var pass = Move(ref currentpos, rotation);
            result += pass;
        }

        Console.WriteLine(result);
    }

    static int Move(ref int pos, int rotation)
    {
        var pass = 0;

        if (rotation < 0)
        {
            for (var i = 0; i < Math.Abs(rotation); i++)
            {
                pos--;
                if (pos == -1)
                {
                    pos = 99;
                }
                if (pos == 0)
                {
                    pass++;
                }
            }
        }
        else
        {
            for (var i = 0; i < rotation; i++)
            {
                pos++;
                if (pos == 100)
                {
                    pos = 0;
                }
                if (pos == 0)
                {
                    pass++;
                }
            }
        }

        return pass;
    }
}
