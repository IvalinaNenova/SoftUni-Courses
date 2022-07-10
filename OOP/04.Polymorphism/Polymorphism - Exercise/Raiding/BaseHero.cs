namespace Raiding
{
    public abstract class BaseHero
    {
        private string name;
        private string type;

        public BaseHero(string name, string type)
        {
            Name = name;
            Type = type;
        }
        public string Name
        {
            get => name;
            set => name = value;
        }

        public string Type
        {
            get => type;
            set => type = value;
        }
        public abstract int Power { get; }


        public abstract string CastAbility();
    }
}
