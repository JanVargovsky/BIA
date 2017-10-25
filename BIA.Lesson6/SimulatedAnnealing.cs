using BIA.Shared.TestFunctions;
using System;

namespace BIA.Lesson6
{
    public class SimulatedAnnealing
    {
        readonly Random random;
        readonly ParameterRestriction parameterRestriction;

        public SimulatedAnnealing()
        {
            random = new Random();
            parameterRestriction = new ParameterRestriction();
        }

        float NextFloat((float min, float max) minMax) => (float)random.NextDouble() * (minMax.max - minMax.min) + minMax.min;

        public float[] GenerateNextPoint(float[] input, float range, TestFunctionBase function)
        {
            float[] GeneratePoint(float[] p)
            {
                var result = new float[p.Length];
                for (int i = 0; i < p.Length; i++)
                    result[i] = NextFloat((p[i] - range / 2, p[i] + range / 2));
                return result;
            }

            const int T0 = 2000;
            const float Alpha = 0.99f;
            const float Tn = 1e-6f;

            float t = T0;
            var x0 = input;
            int it = 0;
            do
            {
                float[] x = GeneratePoint(x0);
                float f = function.Calculate(x0) - function.Calculate(x);

                if (f > 0)
                    x0 = x;
                else
                {
                    var r = random.NextDouble();
                    var v = Math.Pow(Math.E, -Math.E / t);
                    if (r < v)
                        x0 = x;
                    t *= Alpha;
                }
                it++;
            } while (t >= Tn);

            return x0;
        }
    }
}
