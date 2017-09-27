using System;

namespace BIA.Lesson2.TestFunctions
{
    public class EasomFunction : TestFunctionBase
    {
        public EasomFunction() : base(-100f, 100f)
        {
        }

        public override float Calculate(params float[] values)
        {
            var x = values[0];
            var y = values[1];

            var xMinusPI = (x - Math.PI);
            var yMinusPI = (y - Math.PI);
            return (float)(-Math.Cos(x) * Math.Cos(y) * Math.Exp(-(xMinusPI * xMinusPI + yMinusPI * yMinusPI)));
        }
    }
}
