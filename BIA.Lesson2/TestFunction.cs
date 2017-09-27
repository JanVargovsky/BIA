using System;

namespace BIA.Lesson2
{
    class TestFunction
    {
        public Func<float, float, float> Function { get; }

        public float MinX { get; }
        public float MaxX { get; }

        public float MinY { get; }
        public float MaxY { get; }

        public TestFunction(Func<float, float, float> func, float min, float max)
            :this(func, min, max, min, max)
        {
        }

        public TestFunction(Func<float, float, float> func, float minX, float maxX, float minY, float maxY)
        {
            Function = func;
            MinX = minX;
            MaxX = maxX;
            MinY = minY;
            MaxY = maxY;
        }
    }
}
