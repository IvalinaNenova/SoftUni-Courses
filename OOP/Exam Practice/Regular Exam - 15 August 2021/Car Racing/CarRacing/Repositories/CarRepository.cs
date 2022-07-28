using System;
using System.Collections.Generic;
using System.Text;
using CarRacing.Models.Cars.Contracts;
using CarRacing.Repositories.Contracts;

namespace CarRacing.Repositories
{
    public class CarRepository : IRepository<ICar>
    {
        public IReadOnlyCollection<ICar> Models => throw new NotImplementedException();

        public void Add(ICar model)
        {
            throw new NotImplementedException();
        }

        public bool Remove(ICar model)
        {
            throw new NotImplementedException();
        }

        public ICar FindBy(string property)
        {
            throw new NotImplementedException();
        }
    }
}
