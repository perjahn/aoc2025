using System;
using System.IO;

class Program
{
    static void Main()
    {
        var rows = File.ReadAllLines("input.txt");

        var sum = FindMaxJoltage(rows);

        Console.WriteLine(sum);
    }

    static int FindMaxJoltage(string[] batteries)
    {
        var sum = 0;

        foreach (var bank in batteries)
        {
            var firstDigit = -1;
            var secondDigit = -1;

            for (var c = '9'; c >= '0'; c--)
            {
                var index = bank[..^1].IndexOf(c);
                if (index >= 0)
                {
                    firstDigit = index;
                    break;
                }
            }
            for (var c = '9'; c >= '0'; c--)
            {
                var index = bank[(firstDigit + 1)..].LastIndexOf(c);
                if (index >= 0)
                {
                    secondDigit = firstDigit + 1 + index;
                    break;
                }
            }

            sum += int.Parse($"{bank[firstDigit]}{bank[secondDigit]}");
        }

        return sum;
    }
}
