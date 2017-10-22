using BIA.Shared.TestFunctions;
using MoreLinq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BIA.Lesson5
{
    public class PopulationGenerator
    {
        readonly Random random;
        readonly MinMax<float>[] borders;

        public PopulationGenerator(params MinMax<float>[] borders)
        {
            random = new Random();
            this.borders = borders;
        }

        float NextFloat((float min, float max) minMax) => (float)random.NextDouble() * (minMax.max - minMax.min) + minMax.min;

        public IEnumerable<float[]> GenerateFirstPopulation(int populationCount)
        {
            float[] Generate() =>
                Enumerable.Range(0, borders.Length)
                .Select(t => NextFloat(borders[t]))
                .ToArray();

            while (populationCount-- > 0)
                yield return Generate();
        }

        public IEnumerable<float[]> GenerateNextPopulation(IEnumerable<float[]> input, int pointsAroundToGenerate, float range, TestFunctionBase function)
        {
            float[] GeneratePoint(float[] p)
            {
                var result = new float[p.Length];
                for (int i = 0; i < p.Length; i++)
                    result[i] = NextFloat((p[i] - range / 2, p[i] + range / 2));
                return result;
            }

            foreach (var item in input)
            {
                var newPointsAround = Enumerable.Range(0, pointsAroundToGenerate)
                    .Select(_ => GeneratePoint(item))
                    .Select(t => new { Point = t, Fitness = function.Calculate(t) })
                    .ToArray();

                var min = newPointsAround.MinBy(t => t.Fitness);
                yield return min.Point;
            }
        }
    }
}
