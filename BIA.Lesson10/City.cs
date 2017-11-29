using System.Diagnostics;

namespace BIA.Lesson10
{
    [DebuggerDisplay("{Id}")]
    public class City
    {
        public int X { get; }
        public int Y { get; }
        static int id;
        public int Id { get; }

        public City(int v1, int v2)
        {
            X = v1;
            Y = v2;
            Id = id++;
        }

        public override bool Equals(object obj)
        {
            var city = obj as City;
            return city != null &&
                   X == city.X &&
                   Y == city.Y;
        }

        public override int GetHashCode()
        {
            var hashCode = 1861411795;
            hashCode = hashCode * -1521134295 + X.GetHashCode();
            hashCode = hashCode * -1521134295 + Y.GetHashCode();
            return hashCode;
        }
    }
}