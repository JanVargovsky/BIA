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
            const float PRT = 0.3f;

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

                foreach (var p in input)
                {
                    float[] point = new float[D];
                    float[] bestPoint = p;

                    for (float t = Step; t < PathLength; t += Step)
                    {
                        var prtVector = GetPRTVector();
                        for (int i = 0; i < D; i++)
                            point[i] = p[i] + (leader[i] - p[i]) * t * prtVector[i];

                        if (function.Calculate(point) < function.Calculate(bestPoint))
                            point.CopyTo(bestPoint, 0);
                    }

                    population.Add(bestPoint);
                }
            }

            return population;
        }
    }
}
