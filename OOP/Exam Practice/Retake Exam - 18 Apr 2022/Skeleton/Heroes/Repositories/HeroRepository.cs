using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Heroes.Models.Contracts;
using Heroes.Repositories.Contracts;

namespace Heroes.Repositories
{
    public class HeroRepository : IRepository<IHero>
    {
        private List<IHero> models;

        public HeroRepository()
        {
            models = new List<IHero>();
        }
        public IReadOnlyCollection<IHero> Models => models;
        public void Add(IHero model)
        {
            models.Add(model);
        }

        public bool Remove(IHero model)
        {
            return models.Remove(model);
        }

        public IHero FindByName(string name)
        {
            return models.FirstOrDefault(h => h.Name == name);
        }
    }
}
