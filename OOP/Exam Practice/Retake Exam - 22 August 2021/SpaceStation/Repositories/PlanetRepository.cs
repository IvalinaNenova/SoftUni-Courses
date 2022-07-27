using SpaceStation.Models.Planets.Contracts;
using SpaceStation.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace SpaceStation.Repositories
{
    public class PlanetRepository : IRepository<IPlanet>
    {
        private List<IPlanet> models;

        public PlanetRepository()
        {
            models = new List<IPlanet>();
        }
        public IReadOnlyCollection<IPlanet> Models => models;

        public void Add(IPlanet model)
        {
            models.Add(model);
        }

        public bool Remove(IPlanet model)
        {
            return models.Remove(model);
        }

        public IPlanet FindByName(string name)
        {
            return models.FirstOrDefault(p => p.Name == name);
        }
    }
}
