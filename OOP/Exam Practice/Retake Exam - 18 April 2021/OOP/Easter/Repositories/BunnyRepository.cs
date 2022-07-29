using System;
using System.Collections.Generic;
using System.Text;
using Easter.Models.Bunnies.Contracts;
using Easter.Repositories.Contracts;

namespace Easter.Repositories
{
    public class BunnyRepository : IRepository<IBunny>
    {
        public IReadOnlyCollection<IBunny> Models => throw new NotImplementedException();

        public void Add(IBunny model)
        {
            throw new NotImplementedException();
        }

        public bool Remove(IBunny model)
        {
            throw new NotImplementedException();
        }

        public IBunny FindByName(string name)
        {
            throw new NotImplementedException();
        }
    }
}
