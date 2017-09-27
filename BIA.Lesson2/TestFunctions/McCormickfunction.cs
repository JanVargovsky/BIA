using System;

namespace BIA.Lesson2.TestFunctions
{
    public class McCormickfunction : TestFunctionBase
    {
        public McCormickfunction() : base(-1.5f, 4f, -3f, 4f)
        {
        }

        public override float Calculate(params float[] values)
        {
            var x = values[0];
            var y = values[1];

            var a = Math.Sin(x + y);
            var b = (x - y) * (x - y);
            var c = 1.5 * x + 2.5 * y + 1;

            return (float)(a + b - c);
        }
    }
}
