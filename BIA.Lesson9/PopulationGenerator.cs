using BIA.Shared.TestFunctions;
using MoreLinq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BIA.Lesson9
{
    public class PopulationGenerator
    {
        readonly Random random;
        readonly MinMax<float>[] borders;
        readonly ParticleSwarmAlgorithm pso;

        public PopulationGenerator(params MinMax<float>[] borders)
        {
            random = new Random();
            this.borders = borders;
            pso = new ParticleSwarmAlgorithm();
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

        public IEnumerable<float[]> GenerateNextPopulation(float[][] input, TestFunctionBase function, int iterations)
        {
            return pso.GenerateNextPopulation(input, function, iterations);
        }
    }
}
