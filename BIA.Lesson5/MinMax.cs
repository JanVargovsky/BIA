namespace BIA.Lesson5
{
    public class MinMax<T>
    {
        public T Min { get; set; }
        public T Max { get; set; }

        public MinMax(T min, T max)
        {
            Min = min;
            Max = max;
        }

        public static implicit operator MinMax<T>((T Min, T Max) value) => 
            new MinMax<T>(value.Min, value.Max);

        public static implicit operator (T Min, T Max)(MinMax<T> value) =>
            (value.Min, value.Max);
    }
}
