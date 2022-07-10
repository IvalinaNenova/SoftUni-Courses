using System;
using System.Collections.Generic;

namespace Raiding
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<BaseHero> raidGroup = new List<BaseHero>();

            int n = int.Parse(Console.ReadLine());

            BaseHero hero = null;

            for (int i = 0; i < n; i++)
            {
                string name = Console.ReadLine();
                string type = Console.ReadLine();

                try
                {
                    hero = HeroFactory.CreateHero(name, type);
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                    i--;
                    continue;
                }

                raidGroup.Add(hero);
            }

            int bossPower = int.Parse(Console.ReadLine());

            int sum = 0;

            foreach (var baseHero in raidGroup)
            {
                Console.WriteLine(baseHero.CastAbility());
                sum += baseHero.Power;
            }

            Console.WriteLine(sum >= bossPower
                ? "Victory!"
                : "Defeat...");
        }
    }
}
