using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Mission.Contracts;
using SpaceStation.Models.Planets.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace SpaceStation.Models.Mission
{
    public class Mission : IMission
    {
        public void Explore(IPlanet planet, ICollection<IAstronaut> astronauts)
        {
            foreach (var astronaut in astronauts.Where(a => a.CanBreath == true))
            {
                while(planet.Items.Count > 0)
                {
                    var item = planet.Items.ElementAt(0);

                    astronaut.Breath();
                    astronaut.Bag.Items.Add(item);
                    planet.Items.Remove(item);

                    if (!astronaut.CanBreath)
                    {
                        break;
                    }
                }
            }
        }
    }
}
