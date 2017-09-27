using System;
using System.Linq;

namespace BIA.Lesson2.TestFunctions
{
    public class RastriginFunction : TestFunctionBase
    {
        public int A { get; }

        public RastriginFunction(int a) : base(-5.12f, 5.12f)
        {
            A = a;
        }

        public override float Calculate(params float[] values)
        {
            return A * values.Length + values.Sum(t => t * t - A * (float)Math.Cos(2 * Math.PI * t));
        }
    }
}
