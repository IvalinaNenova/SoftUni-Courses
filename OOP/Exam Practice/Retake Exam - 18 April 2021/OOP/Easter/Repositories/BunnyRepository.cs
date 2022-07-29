using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Easter.Models.Bunnies.Contracts;
using Easter.Repositories.Contracts;

namespace Easter.Repositories
{
    public class BunnyRepository : IRepository<IBunny>
    {
        private List<IBunny> models;

        public BunnyRepository()
        {
            models = new List<IBunny>();
        }
        public IReadOnlyCollection<IBunny> Models => models;

        public void Add(IBunny model)
        {
            models.Add(model);
        }

        public bool Remove(IBunny model)
        {
            return models.Remove(model);
        }

        public IBunny FindByName(string name)
        {
            return models.FirstOrDefault(b => b.Name == name);
        }
    }
}
