using BIA.Shared.TestFunctions;
using MoreLinq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BIA.Lesson9
{
    public class ParticleSwarmAlgorithm
    {
        readonly Random random;

        public ParticleSwarmAlgorithm()
        {
            random = new Random();
        }

        class PointWithVelocity
        {
            public float[] Point { get; set; }
            public float Velocity { get; set; }
        }

        public IEnumerable<float[]> GenerateNextPopulation(float[][] input, TestFunctionBase function, int iterations)
        {
            int D = input[0].Length;
            var pBest = input.MinBy(t => function.Calculate(t));
            var gBest = input.MinBy(t => function.Calculate(t));

            const float VMAX = 1;
            const float C1 = 2;
            const float C2 = 2;

            float CalculateV(float[] x, float v, int i)
            {
                var value = v + C1 * (float)random.NextDouble() * (pBest[i] - x[i]) +
                    C2 * (float)random.NextDouble() * (gBest[i] - x[i]);

                return Math.Min(value, VMAX);
            }

            float[] CalculateP(float[] p, float v)
            {
                float[] result = new float[p.Length];
                for (int i = 0; i < result.Length; i++)
                    result[i] = CalculateV(p, v, i);
                return result;
            }

            var oldParticles = input.Select(t => new PointWithVelocity
            {
                Velocity = (float)random.NextDouble(),
                Point = t
            }).ToArray();

            var particles = input.Select(t => new PointWithVelocity
            {
                Velocity = (float)random.NextDouble(),
                Point = t
            }).ToArray();

            while (iterations-- > 0)
            {
                for (int i = 0; i < oldParticles.Length; i++)
                {
                    var particle = CalculateP(oldParticles[i].Point, oldParticles[i].Velocity);
                    
                    if (function.Calculate(particle) < function.Calculate(pBest))
                        pBest = particle;
                    if (function.Calculate(pBest) < function.Calculate(gBest))
                        gBest = pBest;

                    particles[i].Point = particle;
                }

                for (int i = 0; i < oldParticles.Length; i++)
                {
                    Array.Copy(particles[i].Point, oldParticles[i].Point, D);
                }
            }

            return particles.Select(t => t.Point);
        }
    }
}
