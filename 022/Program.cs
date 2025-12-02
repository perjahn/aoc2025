using System;
using System.IO;
using System.Linq;

class Program
{
    static void Main()
    {
        var rows = File.ReadAllLines("input.txt");

        (long start, long end)[] ids = [.. rows.SelectMany(r => r.Split(',', StringSplitOptions.RemoveEmptyEntries))
            .Select(id => (id1: long.Parse(id.Split('-')[0]), end: long.Parse(id.Split('-')[1])))];

        var sum = FindInvalidIds(ids);

        Console.WriteLine(sum);
    }

    static long FindInvalidIds((long start, long end)[] ids)
    {
        long sum = 0;

        foreach (var (start, end) in ids)
        {
            for (long id = start; id <= end; id++)
            {
                var s = $"{id}";
                for (var length = 1; length <= s.Length / 2; length++)
                {
                    if (IsRepeating(s, length))
                    {
                        sum += id;
                        break;
                    }
                }
            }
        }

        return sum;
    }

    static bool IsRepeating(string s, int length)
    {
        if (s.Length % length != 0)
        {
            return false;
        }
        for (var i = length; i <= s.Length - length; i += length)
        {
            if (s.Substring(i, length) != s[..length])
            {
                return false;
            }
        }
        return true;
    }
}
