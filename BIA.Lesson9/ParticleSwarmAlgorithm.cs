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

        class Particle
        {
            public float[] Point { get; set; }
            public float[] BestPoint { get; set; }
            public float[] Velocity { get; set; }
        }

        public IEnumerable<float[]> GenerateNextPopulation(float[][] input, TestFunctionBase function, int iterations)
        {
            int D = input[0].Length;
            var gBest = input.MinBy(t => function.Calculate(t));

            const float VMAX = 1;
            const float C1 = 2;
            const float C2 = 2;

            float[] CalculateV(Particle point)
            {
                float[] result = new float[D];
                var x = point.Point;
                var v = point.Velocity;
                for (int i = 0; i < D; i++)
                {
                    var value = v[i] + C1 * (float)random.NextDouble() * (point.BestPoint[i] - x[i]) +
                    C2 * (float)random.NextDouble() * (gBest[i] - x[i]);
                    result[i] = Math.Min(value, VMAX);
                }
                return result;
            }

            float[] CalculateP(float[] p, float[] v)
            {
                float[] result = new float[D];
                for (int i = 0; i < D; i++)
                    result[i] = p[i] + v[i];
                return result;
            }

            Particle Calculate(Particle old)
            {
                var p = new Particle();
                p.Velocity = CalculateV(old);
                p.Point = CalculateP(old.Point, p.Velocity);
                p.BestPoint = old.BestPoint;
                return p;
            }

            var particles = input.Select(t => new Particle
            {
                Velocity = Enumerable.Range(0, D).Select(_ => (float)random.NextDouble()).ToArray(),
                Point = t,
                BestPoint = t,
            }).ToArray();

            while (iterations-- > 0)
            {
                for (int i = 0; i < particles.Length; i++)
                {
                    var particle = particles[i] = Calculate(particles[i]);

                    if (function.Calculate(particle.Point) < function.Calculate(particles[i].BestPoint))
                        particle.Point.CopyTo(particles[i].BestPoint, 0);

                    if (function.Calculate(particles[i].BestPoint) < function.Calculate(gBest))
                        particle.BestPoint.CopyTo(gBest, 0);

                    particles[i].Point = particle.Point;
                    particles[i].Velocity = particle.Velocity;
                }
            }

            return particles.Select(t => t.BestPoint);
        }
    }
}
