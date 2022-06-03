namespace DefiningClasses
{
    public class Engine
    {
        public Engine(int engineSpeed, int enginePower)
        {
            Speed = engineSpeed;
            Power = enginePower;
        }

        //•	Engine: a class with two properties – speed and power,
        public int Speed { get; set; }
        public int Power { get; set; }

    }
}
