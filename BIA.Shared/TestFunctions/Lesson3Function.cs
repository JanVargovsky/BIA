using System;

namespace BIA.Shared.TestFunctions
{
    public class Lesson3Function : TestFunctionBase
    {
        public float F { get; }

        public Lesson3Function(float f) : base(0, 1)
        {
            F = f;
        }

        public override float Calculate(params float[] values)
        {
            var x1 = values[0];
            var x2 = values[1];

            float f1() => x1;
            float g() => 10 + x2;
            const float gStar = 11;
            const float gStarStar = 12;

            var alpha = 0.25d + 3.75d * ((g() - gStarStar) / (gStar - gStarStar));

            var result = Math.Pow(f1() / g(), alpha) - (f1() / g()) * Math.Sin(Math.PI * F * f1() * g());
            return (float)result;
        }
    }
}
