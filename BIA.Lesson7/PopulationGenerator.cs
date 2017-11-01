using BIA.Shared.TestFunctions;
using MoreLinq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BIA.Lesson7
{
    public class PopulationGenerator
    {
        readonly Random random;
        readonly MinMax<float>[] borders;
        readonly DifferentialEvolution differentialEvolution;

        public PopulationGenerator(params MinMax<float>[] borders)
        {
            random = new Random();
            this.borders = borders;
            differentialEvolution = new DifferentialEvolution();
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

        public IEnumerable<float[]> GenerateNextPopulation(float[][] input, TestFunctionBase function)
        {
            return differentialEvolution.GenerateNextPopulation(input, function);
        }
    }
}
