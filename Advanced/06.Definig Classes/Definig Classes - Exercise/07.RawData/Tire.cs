namespace DefiningClasses
{
    public class Tire
    {
        public Tire(double pressure, int age)
        {
            Age = age;
            Pressure = pressure;
        }

        public int Age { get; set; }
        public double Pressure { get; set; }

    }
}
