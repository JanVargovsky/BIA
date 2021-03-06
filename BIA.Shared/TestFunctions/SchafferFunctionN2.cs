﻿using System;

namespace BIA.Shared.TestFunctions
{
    public class SchafferFunctionN2 : TestFunctionBase
    {
        public SchafferFunctionN2() : base(-100f, 100f)
        {
        }

        public override float Calculate(params float[] values)
        {
            var x = values[0];
            var y = values[1];

            var a = Math.Sin(x * x - y * y);
            var b = a * a - 0.5;
            var c = Math.Pow(1 + 0.001 * (x * x + y * y), 2);
            return (float)(0.5 + b / c);
        }
    }
}
