using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gym.Models.Equipment.Contracts;
using Gym.Repositories.Contracts;

namespace Gym.Repositories
{
    public class EquipmentRepository : IRepository<IEquipment>
    {
        private List<IEquipment> models;

        public EquipmentRepository()
        {
            models = new List<IEquipment>();
        }
        public IReadOnlyCollection<IEquipment> Models => models;

        public void Add(IEquipment model)
        {
            models.Add(model);
        }

        public bool Remove(IEquipment model)
        {
            return models.Remove(model);
        }

        public IEquipment FindByType(string type)
        {
            return models.FirstOrDefault(e => e.GetType().Name == type);
        }
    }
}
