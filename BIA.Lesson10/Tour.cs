namespace BIA.Lesson10
{
    public class Tour
    {
        public Tour(City[] cities, float distance)
        {
            Cities = cities;
            Distance = distance;
        }

        public City[] Cities { get; set; }
        public float Distance { get; set; }
    }
}
