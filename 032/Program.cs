using System;
using System.IO;
using System.Linq;
class Program
{
    static void Main()
    {
        var rows = File.ReadAllLines("input.txt");

        var sum = FindMaxJoltage(rows);

        Console.WriteLine(sum);
    }

    static long FindMaxJoltage(string[] batteries)
    {
        long sum = 0;

        foreach (var bank in batteries)
        {
            var digits = new int[12];

            for (var i = 0; i < 12; i++)
            {
                for (var c = '9'; c >= '0'; c--)
                {
                    var s = bank[..^(11 - i)];
                    var index = i == 0 ? s.IndexOf(c) : s.IndexOf(c, digits[i - 1] + 1);

                    if (index >= 0)
                    {
                        digits[i] = index;
                        break;
                    }
                }
            }

            sum += long.Parse($"{string.Join(string.Empty, digits.Select(d => bank[d]))}");
        }

        return sum;
    }
}
