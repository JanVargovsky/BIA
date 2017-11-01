using BIA.Shared.TestFunctions;
using System;
using System.Collections.Generic;

namespace BIA.Lesson7
{
    public class TabuSearch
    {
        readonly Random random;

        public TabuSearch()
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

            var tabu = new HashSet<float[]>();
            var bestPoint = point;
            for (int i = 0; i < iterations; i++)
            {
                float[] newPoint = null;
                do
                    newPoint = GeneratePoint(point);
                while (!tabu.Contains(newPoint));

                tabu.Add(newPoint);

                if (testFunction.Calculate(bestPoint) > testFunction.Calculate(newPoint))
                    bestPoint = newPoint;
            }

            return bestPoint;
        }
    }
}
