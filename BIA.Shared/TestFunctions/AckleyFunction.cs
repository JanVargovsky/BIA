using System;

namespace BIA.Shared.TestFunctions
{
    public class AckleyFunction : TestFunctionBase
    {
        public AckleyFunction() : base(-5f, 5f)
        {
        }

        public override float Calculate(params float[] values)
        {
            var x = values[0];
            var y = values[1];

            var a = -20 * Math.Exp(-0.2d * Math.Sqrt(0.5d * (x * x + y * y)));
            var b = Math.Exp(0.5f * (Math.Cos(2 * Math.PI * x) + Math.Cos(2 * Math.PI * y)));
            var c = Math.E + 20;

            return (float)(a - b + c);
        }
    }
}
