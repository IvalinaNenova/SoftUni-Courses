namespace SpaceStation.Models.Astronauts
{
    public class Biologist : Astronaut
    {
        public Biologist(string name)
            : base(name, 70)
        {
        }

        public override void Breath()
        {
            if ((Oxygen - 5) >= 0)
            {
                Oxygen -= 5;
            }
            else
            {
                Oxygen = 0;
            }
        }
    }
}
