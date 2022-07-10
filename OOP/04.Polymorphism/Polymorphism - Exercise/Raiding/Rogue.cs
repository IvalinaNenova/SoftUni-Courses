namespace Raiding
{
    public class Rogue : BaseHero
    {
        private const int DefaultPower = 80;

        public Rogue(string name, string type)
            : base(name, type)
        {
        }

        public override int Power => DefaultPower;

        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {Name} hit for {Power} damage";
        }
    }
}
