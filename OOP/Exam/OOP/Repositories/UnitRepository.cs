using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace PlanetWars.Repositories
{
    public class UnitRepository : IRepository<IMilitaryUnit>
    {
        private readonly List<IMilitaryUnit> models;

        public UnitRepository()
        {
            models = new List<IMilitaryUnit>();
        }
        public IReadOnlyCollection<IMilitaryUnit> Models => models;

        public void AddItem(IMilitaryUnit model) => models.Add(model);

        public IMilitaryUnit FindByName(string name) => models.FirstOrDefault(m => m.GetType().Name == name);

        public bool RemoveItem(string name) => models.Remove(models.FirstOrDefault(m => m.GetType().Name == name));
    }
}
