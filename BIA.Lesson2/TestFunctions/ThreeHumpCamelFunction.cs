using System;

namespace BIA.Lesson2.TestFunctions
{
    public class ThreeHumpCamelFunction : TestFunctionBase
    {
        public ThreeHumpCamelFunction() : base(-5f, 5f)
        {
        }

        public override float Calculate(params float[] values)
        {
            var x = values[0];
            var y = values[1];

            return (float)(2d * x * x - 1.05d * Math.Pow(x, 4) + (Math.Pow(x, 6) / 6) + x * y + y * y);
        }
    }
}
