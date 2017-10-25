using BIA.Shared.TestFunctions;
using System;

namespace BIA.Lesson6
{
    public class LocalSearch
    {
        readonly Random random;

        public LocalSearch()
        {
            random = new Random();
        }

        float NextFloat(float min, float max) => (float)random.NextDouble() * (max - min) + min;

        public float[] Search(float[] point, TestFunctionBase testFunction, int iterations, float range)
        {
            float[] GeneratePoint(float[] p)
            {
                var result = new float[p.Length];
                for (int i = 0; i < p.Length; i++)
                    result[i] = NextFloat(p[i] - range / 2, p[i] + range / 2);
                return result;
            }

            var bestPoint = point;
            for (int i = 0; i < iterations; i++)
            {
                var newPoint = GeneratePoint(point);
                if (testFunction.Calculate(bestPoint) > testFunction.Calculate(newPoint))
                    bestPoint = newPoint;
            }

            return bestPoint;
        }
    }
}
