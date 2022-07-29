using System;
using System.Collections.Generic;
using System.Text;
using Easter.Models.Eggs.Contracts;
using Easter.Repositories.Contracts;

namespace Easter.Repositories
{
    public class EggRepository : IRepository<IEgg>
    {
        public IReadOnlyCollection<IEgg> Models => throw new NotImplementedException();

        public void Add(IEgg model)
        {
            throw new NotImplementedException();
        }

        public bool Remove(IEgg model)
        {
            throw new NotImplementedException();
        }

        public IEgg FindByName(string name)
        {
            throw new NotImplementedException();
        }
    }
}
