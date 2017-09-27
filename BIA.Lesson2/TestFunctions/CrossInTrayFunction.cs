using System;

namespace BIA.Lesson2.TestFunctions
{
    public class CrossInTrayFunction : TestFunctionBase
    {
        public CrossInTrayFunction() : base(-10f, 10f)
        {
        }

        public override float Calculate(params float[] values)
        {
            var x = values[0];
            var y = values[1];

            var a = Math.Abs(100d - (Math.Sqrt(x * x + y * y) / Math.PI));
            var b = Math.Abs(Math.Sin(x) * Math.Sin(y) * Math.Exp(a));
            var c = Math.Pow(b + 1, 0.1d);

            return (float)(-0.0001d * c);
        }
    }
}
