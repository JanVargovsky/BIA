using System;

namespace BIA.Shared.TestFunctions
{
    public class HolderTableFunction : TestFunctionBase
    {
        public HolderTableFunction() : base(-10f, 10f)
        {
        }

        public override float Calculate(params float[] values)
        {
            var x = values[0];
            var y = values[1];

            var a = Math.Abs(1d - (Math.Sqrt(x * x + y * y) / Math.PI));
            var b = Math.Sin(x) * Math.Cos(y) * Math.Exp(a);

            return (float)(-Math.Abs(b));
        }
    }
}
