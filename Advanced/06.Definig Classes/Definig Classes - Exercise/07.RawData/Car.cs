namespace DefiningClasses
{
    public class Car
    {
        //    Create a constructor that receives all of the information about the Car and creates and initializes the model and its inner components(engine, cargo, and tires).
        public string Model { get; set; }
        public Engine Engine { get; set; }
        public Cargo Cargo { get; set; }
        public Tire[] Tires { get; set; }

        public Car(string model, Engine engine, Cargo cargo, Tire[] tires)
        {
            Model = model;
            Engine = engine;
            Cargo = cargo;
            Tires = tires;
        }

    }
}
