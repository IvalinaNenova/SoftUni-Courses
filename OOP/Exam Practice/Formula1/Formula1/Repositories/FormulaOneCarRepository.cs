using Formula1.Models.Contracts;
using Formula1.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace Formula1.Repositories
{
    public class FormulaOneCarRepository : IRepository<IFormulaOneCar>
    {
        private readonly List<IFormulaOneCar> models;

        public FormulaOneCarRepository()
        {
            this.models = new List<IFormulaOneCar>();
        }

        public IReadOnlyCollection<IFormulaOneCar> Models => models;

        public void Add(IFormulaOneCar model)
        {
            models.Add(model);
        }

        public bool Remove(IFormulaOneCar model)
        {
            return models.Remove(model);
        }

        public IFormulaOneCar FindByName(string name)
        {
            return models.FirstOrDefault(c => c.Model == name);
        }
    }
}
