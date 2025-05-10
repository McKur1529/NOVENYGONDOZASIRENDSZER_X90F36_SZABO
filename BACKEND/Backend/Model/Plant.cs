namespace Backend.Models
{
    public class Plant
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public double Water { get; set; }
        public int Frequency { get; set; }

        
        public Plant() { }

        
        public Plant(string name, string type, double water, int frequency)
        {
            Name = name;
            Type = type;
            Water = water;
            Frequency = frequency;
        }
    }
}