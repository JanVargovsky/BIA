using BIA.Shared.TestFunctions;
using MoreLinq;
using System;
using System.Collections.Generic;

namespace BIA.Lesson8
{
    public class SelfOrganizingMigratingAlgorithm
    {
        readonly Random random;

        public SelfOrganizingMigratingAlgorithm()
        {
            random = new Random();
        }

        public IEnumerable<float[]> GenerateNextPopulation(float[][] input, TestFunctionBase function)
        {
            var population = new List<float[]>();
            int D = input[0].Length;
            const float Step = 0.11f;
            const float PathLength = 3;
            const float PRT = 0.1f;

            // PRT - perturbacni vektor
            int[] GetPRTVector()
            {
                var prtVector = new int[D];
                for (int i = 0; i < prtVector.Length; i++)
                {
                    if ((float)random.NextDouble() < PRT)
                        prtVector[i] = 1;
                    else
                        prtVector[i] = 0;
                }
                return prtVector;
            }

            //for (int migration = 0; migration < migrations; migration++)
            {
                var leader = input.MinBy(t => function.Calculate(t));
                var prtVector = GetPRTVector();

                foreach (var p in input)
                {
                    float[] point = new float[D];
                    float[] bestPoint = null;

                    for (float t = 0; t < PathLength; t += Step)
                    {
                        for (int i = 0; i < D; i++)
                            point[i] = p[i] + (leader[i] - p[i]) * i * prtVector[i];

                        if (bestPoint == null || function.Calculate(point) < function.Calculate(bestPoint))
                            bestPoint = point;
                    }

                    population.Add(point);
                }
            }

            return population;
        }
    }
}
