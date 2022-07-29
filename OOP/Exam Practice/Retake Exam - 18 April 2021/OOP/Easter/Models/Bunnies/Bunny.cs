using System;
using System.Collections.Generic;
using System.Text;
using Easter.Models.Bunnies.Contracts;
using Easter.Models.Dyes.Contracts;
using Easter.Utilities.Messages;

namespace Easter.Models.Bunnies
{
    public abstract class Bunny : IBunny
    {
        private string name;
        private int energy;
        private ICollection<IDye> dyes;

        protected Bunny(string name, int energy)
        {
            Name = name;
            Energy = energy;
            dyes = new List<IDye>();
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidBunnyName);
                }

                name = value;
            }
        }

        public int Energy
        {
            get => energy;
            protected set
            {
                if (value<0)
                {
                    value = 0;
                }

                energy = value;
            }
        }

        public ICollection<IDye> Dyes => dyes;

        public abstract void Work();

        public void AddDye(IDye dye)
        {
            dyes.Add(dye);
        }
    }
}
