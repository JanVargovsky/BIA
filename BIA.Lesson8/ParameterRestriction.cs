namespace BIA.Lesson8
{
    public class ParameterRestriction
    {
        public float Normalize(float value, float min, float max)
        {
            if (value < min)
                return min;
            if (value > max)
                return max;
            return value;
        }

        public int Normalize(int value, int min, int max)
        {
            if (value < min)
                return min;
            if (value > max)
                return max;
            return value;
        }

        public float Normalize(float value, MinMax<float> minMax) =>
            Normalize(value, minMax.Min, minMax.Max);

        public int Normalize(int value, MinMax<int> minMax) =>
            Normalize(value, minMax.Min, minMax.Max);
    }
}
