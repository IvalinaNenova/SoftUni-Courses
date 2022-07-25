using Heroes.Models.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace Heroes.Models.Map
{
    public class Map : IMap
    {
        public string Fight(ICollection<IHero> players)
        {
            List<IHero> knights = players.Where(p => p.GetType().Name == "Knight").ToList();
            List<IHero> barbarians = players.Where(p => p.GetType().Name == "Barbarian").ToList();

            bool knightsAreAlive = knights.Any(k => k.IsAlive == true);
            bool knightsWin = false;
            bool barbariansWin = false;
            while (true)
            {
                foreach (var knight in knights.Where(k=> k.IsAlive == true))
                {
                    foreach (var barbarian in barbarians.Where(b=> b.IsAlive == true))
                    {
                        barbarian.TakeDamage(knight.Weapon.DoDamage());
                    }
                    if (barbarians.All(b => b.IsAlive == false))
                    {
                        knightsWin = true;
                        break;
                    }
                }

                if (knightsWin)
                {
                    break;
                }
                foreach (var barbarian in barbarians.Where(b => b.IsAlive == true))
                {
                    foreach (var knight in knights.Where(k => k.IsAlive == true))
                    {
                        knight.TakeDamage(barbarian.Weapon.DoDamage());
                    }
                    if (knights.All(k => k.IsAlive == false))
                    {
                        barbariansWin = true;
                        break;
                    }
                }

                if (barbariansWin)
                {
                    break;
                }
            }

            if (knightsWin)
            {
                int casualties = knights.Count(x => x.IsAlive == false);
                return $"The knights took {casualties} casualties but won the battle.";
            }
            else
            {
                int casualties = barbarians.Count(x => x.IsAlive == false);
                return $"The barbarians took {casualties} casualties but won the battle.";
            }
        }
    }
}
