namespace DefiningClasses
{
    public class Cargo
    {
        public Cargo(int weight, string type)
        {
            Type = type;
            Weight = weight;
        }

        //•	Cargo: a class with two properties – type and weight 
        public string Type { get; set; }
        public int Weight { get; set; }

    }
}
