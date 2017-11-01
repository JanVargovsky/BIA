using BIA.Shared.TestFunctions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BIA.Lesson7
{
    public class DifferentialEvolution
    {
        readonly Random random;

        public DifferentialEvolution()
        {
            random = new Random();
        }

        public IEnumerable<float[]> GenerateNextPopulation(float[][] input, TestFunctionBase function)
        {
            const float F = 0.5f;
            const float CR = 0.9f;
            int NP = input.Length;
            int D = input[0].Length;

            float[] GenerateNextPoint(float[] p)
            {
                // aktivni jedinec
                var target = p;
                // tri nahodne vybrani jedinci
                var solutionVectors = new[] { input[random.Next(NP)], input[random.Next(NP)], input[random.Next(NP)] };

                // diferencni vahovy vektor
                float[] v = Enumerable.Range(0, D)
                    .Select(i => solutionVectors[2][i] + F * (solutionVectors[0][i] - solutionVectors[1][i]))
                    .ToArray();

                float[] u = new float[D];
                var j = random.Next(D);
                for (int i = 0; i < D; i++)
                {
                    var r = random.NextDouble();
                    if (r < CR || i == j)
                        u[i] = v[i];
                    else
                        u[i] = target[i];
                }

                if (function.Calculate(target) > function.Calculate(u))
                    return u;
                else
                    return target;
            }

            return input.Select(GenerateNextPoint);
        }
    }
}
