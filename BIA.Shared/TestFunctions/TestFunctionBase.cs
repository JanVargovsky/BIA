using System;

namespace BIA.Shared.TestFunctions
{
    public abstract class TestFunctionBase
    {
        public float MinX { get; }
        public float MaxX { get; }

        public float MinY { get; }
        public float MaxY { get; }

        public TestFunctionBase(float min, float max)
            :this(min, max, min, max)
        {
        }

        public TestFunctionBase(float minX, float maxX, float minY, float maxY)
        {
            MinX = minX;
            MaxX = maxX;
            MinY = minY;
            MaxY = maxY;
        }

        public abstract float Calculate(params float[] values);
    }
}
