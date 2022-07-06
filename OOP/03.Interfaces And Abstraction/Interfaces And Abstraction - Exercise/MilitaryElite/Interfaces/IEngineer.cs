using System.Collections.Generic;
using MilitaryElite.Classes;

namespace MilitaryElite.Interfaces
{
    public interface IEngineer : ISpecialisedSoldier
    {
        public List<IRepair> Repairs { get; set; }
    }
}
