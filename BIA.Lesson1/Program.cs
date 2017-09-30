using MoreLinq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace BIA.Lesson1
{
    class Program
    {
        static void Main(string[] args)
        {
            var results = new Dictionary<int, (long TotalTime, long TotalSolutions)>();

            for (int i = 2; i <= 14; i++)
            {
                Console.WriteLine($"Started {i}");
                Stopwatch sw = Stopwatch.StartNew();
                var allnodes = Enumerable.Range(0, i)
                    .Select(t => (char)('a' + t))
                    .ToList();

                var exceptFirst = allnodes.Skip(1).ToList();
                var permutations = MoreEnumerable.Permutations(exceptFirst);
                var count = permutations.LongCount();

                sw.Stop();
                results[i] = (sw.ElapsedMilliseconds, count);

                Console.WriteLine($"Solution count {count}, computed in {sw.ElapsedMilliseconds}ms");
            }

            File.WriteAllText("results.csv", string.Join(Environment.NewLine, results.Select(t => string.Format("{0},{1},{2}", t.Key, t.Value.TotalSolutions, t.Value.TotalTime))));

            Console.WriteLine("Done");
        }
    }
}
