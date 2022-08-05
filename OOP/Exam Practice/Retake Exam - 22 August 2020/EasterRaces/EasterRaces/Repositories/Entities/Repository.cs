using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EasterRaces.Repositories.Contracts;

namespace EasterRaces.Repositories.Entities
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        private List<T> models;

        protected Repository()
        {
            models = new List<T>();
        }
        public List<T> Models => models;

        public abstract T GetByName(string name);

        public IReadOnlyCollection<T> GetAll()
        {
            return models as IReadOnlyCollection<T>;
        }

        public void Add(T model)
        {
            models.Add(model);
        }

        public bool Remove(T model)
        {
            return models.Remove(model);
        }
    }
}
