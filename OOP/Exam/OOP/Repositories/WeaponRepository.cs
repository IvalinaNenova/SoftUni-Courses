using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PlanetWars.Repositories
{
    public class WeaponRepository : IRepository<IWeapon>
    {
        private readonly List<IWeapon> models;

        public WeaponRepository()
        {
            models = new List<IWeapon>();
        }
        public IReadOnlyCollection<IWeapon> Models => models;

        public void AddItem(IWeapon model) => models.Add(model);

        public IWeapon FindByName(string name) => models.FirstOrDefault(w => w.GetType().Name == name);

        public bool RemoveItem(string name) => models.Remove(models.FirstOrDefault(m => m.GetType().Name == name));
    }
}
