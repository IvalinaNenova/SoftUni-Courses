namespace Raiding
{
    public class Paladin : BaseHero
    {
        private const int DefaultPower = 100;
        public Paladin(string name, string type)
            : base(name, type)
        {
        }

        public override int Power => DefaultPower;

        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {Name} healed for {Power}";
        }
    }
}
