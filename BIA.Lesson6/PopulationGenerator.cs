using BIA.Shared.TestFunctions;
using MoreLinq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BIA.Lesson6
{
    public class PopulationGenerator
    {
        readonly Random random;
        readonly MinMax<float>[] borders;
        readonly SimulatedAnnealing simulatedAnnealing;

        public PopulationGenerator(params MinMax<float>[] borders)
        {
            random = new Random();
            this.borders = borders;
            simulatedAnnealing = new SimulatedAnnealing();
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
            float[] GeneratePoint(float[] p) => simulatedAnnealing.GenerateNextPoint(p, range, function);

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
