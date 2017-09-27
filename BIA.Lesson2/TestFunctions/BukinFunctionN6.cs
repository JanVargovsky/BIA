using System;

namespace BIA.Lesson2.TestFunctions
{
    public class BukinFunctionN6 : TestFunctionBase
    {
        public BukinFunctionN6() : base(-15f, -5f, -3f, 3f)
        {
        }

        public override float Calculate(params float[] values)
        {
            var x = values[0];
            var y = values[1];

            return (float)(100 * Math.Sqrt(Math.Abs(y - 0.01 * x * x)) + 0.01 * Math.Abs(x + 10));
        }
    }
}
