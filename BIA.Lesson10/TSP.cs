using MoreLinq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BIA.Lesson10
{
    public class TSP
    {
        readonly Random random;
        readonly City[] cities;

        public City[] Cities => cities;

        public TSP()
        {
            random = new Random();
            cities = new[]
            {
                new City(60, 200),
                new City(180, 200),
                new City(80, 180),
                new City(140, 180),
                new City(20, 160),
                new City(100, 160),
                new City(200, 160),
                new City(140, 140),
                new City(40, 120),
                new City(100, 120),
                new City(180, 100),
                new City(60, 80),
                new City(120, 80),
                new City(180, 60),
                new City(20, 40),
                new City(100, 40),
                new City(200, 40),
                new City(20, 20),
                new City(60, 20),
                new City(160, 20),
            };
        }

        float CalculateFittness(IList<City> cities)
        {
            double Length(City a, City b) => Math.Sqrt(Math.Pow(a.X - b.X, 2) + Math.Pow(a.Y - b.Y, 2));

            double r = 0;
            for (int i = 0; i < cities.Count - 1; i++)
                r += Length(cities[i], cities[i + 1]);

            r += Length(cities[0], cities[cities.Count - 1]);
            return (float)r;
        }

        public Tour Solve()
        {
            const int NP = 50;
            const int G = 1000;
            var population = Enumerable.Range(0, NP)
                .Select(t =>
                {
                    var c = cities.OrderBy(_ => random.Next()).ToArray();
                    var tour = new Tour(c, CalculateFittness(c));
                    return tour;
                })
                .OrderBy(t => t.Distance)
                .ToArray();

            for (int it = 0; it < G; it++)
            {
                var newPopulation = new Tour[NP];

                for (int i = 0; i < NP; i++)
                {
                    newPopulation[i] = new Tour(new City[cities.Length], -1);

                    // krizeni (1 cast)
                    int first = random.Next(cities.Length - 1);
                    int last = random.Next(first + 1, cities.Length - 1);
                    // a b c d  - aktualni
                    // first = 1, last = 2
                    // _ b c _ - zanechani existujicich na intervalu <first, last>
                    for (int j = 0; j <= last - first; j++)
                        newPopulation[i].Cities[j] = population[i].Cities[j + first];

                    // kriyeni (2 cast)
                    // _ b c _ - aktualni
                    // d c b a - nahodne vybrany
                    // => mutace
                    // d b c a
                    int index = random.Next(NP / 4);
                    var remainingCities = population[index].Cities
                        .Where((c, j) => !newPopulation[i].Cities.Contains(c))
                        .ToArray();

                    for (int j = last - first + 1, ri = 0; j < cities.Length; j++, ri++)
                        newPopulation[i].Cities[j] = remainingCities[ri];

                    // mutace
                    var mutationFirst = random.Next(cities.Length);
                    var mutationLast = random.Next(cities.Length);
                    var tmp = newPopulation[i].Cities[mutationFirst];
                    newPopulation[i].Cities[mutationFirst] = newPopulation[i].Cities[mutationLast];
                    newPopulation[i].Cities[mutationLast] = tmp;

                    newPopulation[i].Distance = CalculateFittness(newPopulation[i].Cities);

                    if (population[i].Distance < newPopulation[i].Distance)
                        newPopulation[i] = population[i];
                }

                population = newPopulation.OrderBy(t => t.Distance).ToArray();
            }

            var best = population.MinBy(t => t.Distance);
            return best;
        }
    }
}
