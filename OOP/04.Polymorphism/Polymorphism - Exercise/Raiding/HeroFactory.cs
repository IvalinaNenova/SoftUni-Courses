using System;

namespace Raiding
{
    static class HeroFactory
    {
        public static BaseHero CreateHero(string name, string type)
        {
            switch (type)
            {
                case "Druid":
                    return new Druid(name, type);
                case "Paladin":
                    return new Paladin(name, type);
                case "Rogue":
                    return new Rogue(name, type);
                case "Warrior":
                    return new Warrior(name, type);
                default:
                    throw new ArgumentException("Invalid hero!");
            }
        }
    }
}
