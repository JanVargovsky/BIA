using System;
using System.Linq;

namespace BIA.Lesson2
{
    public class TestFunctions
    {
        public float RastriginFunction(int a, params float[] values)
        {
            return a * values.Length + values.Sum(t => t * t - a * (float)Math.Cos(2 * Math.PI * t));
        }

        public float AckleyFunction(float x, float y)
        {
            var a = -20 * Math.Exp(-0.2d * Math.Sqrt(0.5d * (x * x + y * y)));
            var b = Math.Exp(0.5f * (Math.Cos(2 * Math.PI * x) + Math.Cos(2 * Math.PI * y)));
            var c = Math.E + 20;

            return (float)(a - b + c);
        }

        public float SphereFunction(params float[] values)
        {
            return values.Sum(t => t * t);
        }

        public float EasomFunction(float x, float y)
        {
            var xMinusPI = (x - Math.PI);
            var yMinusPI = (y - Math.PI);
            return (float)(-Math.Cos(x) * Math.Cos(y) * Math.Exp(-(xMinusPI * xMinusPI + yMinusPI * yMinusPI)));
        }

        public float ThreeHumpCamelFunction(float x, float y)
        {
            return (float)(2d * x * x - 1.05d * Math.Pow(x, 4) + (Math.Pow(x, 6) / 6) + x * y + y * y);
        }

        public float CrossInTrayFunction(float x, float y)
        {
            var a = Math.Abs(100d - (Math.Sqrt(x * x + y * y) / Math.PI));
            var b = Math.Abs(Math.Sin(x) * Math.Sin(y) * Math.Exp(a));
            var c = Math.Pow(b + 1, 0.1d);

            return (float)(-0.0001d * c);
        }

        public float HolderTableFunction(float x, float y)
        {
            var a = Math.Abs(1d - (Math.Sqrt(x * x + y * y) / Math.PI));
            var b = Math.Sin(x) * Math.Cos(y) * Math.Exp(a);

            return (float)(-Math.Abs(b));
        }

        public float McCormickfunction(float x, float y)
        {
            var a = Math.Sin(x + y);
            var b = (x - y) * (x - y);
            var c = 1.5 * x + 2.5 * y + 1;

            return (float)(a + b - c);
        }

        public float SchafferFunctionN4(float x, float y)
        {
            var a = Math.Cos(Math.Sin(Math.Abs(x * x - y * y)));
            var b = a * a - 0.5f;
            var c = Math.Pow(1 + 0.001 * (x * x + y * y), 2);
            return (float)(0.5 + b / c);
        }

        public float SchafferFunctionN2(float x, float y)
        {
            var a = Math.Sin(x * x - y * y);
            var b = a * a - 0.5;
            var c = Math.Pow(1 + 0.001 * (x * x + y * y), 2);
            return (float)(0.5 + b/c);
        }

        public float MatyasFunction(float x, float y)
        {
            return (float)(0.26 * (x * x + y * y) - 0.48 * x * y);
        }

        public float BukinFunctionN6(float x, float y)
        {
            return (float)(100 * Math.Sqrt(Math.Abs(y - 0.01 * x * x)) + 0.01 * Math.Abs(x + 10));
        }
    }
}
