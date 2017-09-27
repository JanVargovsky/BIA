using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace BIA.Lesson1
{
    class Program
    {
        class Record
        {
            public long TotalTime { get; set; }
            public int TotalSolutions { get; set; }
        }

        static void Main(string[] args)
        {
            var results = new Dictionary<int, Record>();

            for (int i = 2; i <= 11; i++)
            {
                Console.WriteLine("Total nodes " + i);

                Stopwatch sw = Stopwatch.StartNew();

                var allnodes = Enumerable.Range(0, i + 1)
                    .Select(t => (char)('a' + t))
                    .ToList();

                var exceptFirst = allnodes.Skip(1).ToList();
                var permutations = GetPermutations(exceptFirst, exceptFirst.Count)
                    //.ToList()
                    ;

                //StringBuilder sb = new StringBuilder();
                foreach (var nodes in permutations)
                {
                    //    string path = string.Format("{0}-{1}-{0}", allnodes[0], string.Join("-", nodes));
                    //    sb.AppendLine(path);
                }

                //Console.WriteLine(sb);

                sw.Stop();
                results[i] = new Record
                {
                    TotalSolutions = permutations.Count(),
                    TotalTime = sw.ElapsedMilliseconds,
                };

                Console.WriteLine("computed in {0}", sw.ElapsedMilliseconds);
            }

            File.WriteAllText("results.csv", string.Join(Environment.NewLine, results.Select(t => string.Format("{0},{1},{2}", t.Key, t.Value.TotalSolutions, t.Value.TotalTime))));

            Console.WriteLine("Done");
        }

        static IEnumerable<IEnumerable<T>> GetPermutations<T>(IEnumerable<T> list, int length)
        {
            if (length == 1) return list.Select(t => new T[] { t });

            return GetPermutations(list, length - 1)
                .SelectMany(t => list.Where(e => !t.Contains(e)),
                    (t1, t2) => t1.Concat(new T[] { t2 }));
        }
    }
}
