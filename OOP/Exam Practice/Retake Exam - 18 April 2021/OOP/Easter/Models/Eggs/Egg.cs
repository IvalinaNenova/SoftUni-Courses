using System;
using System.Collections.Generic;
using System.Text;
using Easter.Models.Eggs.Contracts;

namespace Easter.Models.Eggs
{
    public class Egg : IEgg
    {
        public Egg(string name, int energyRequired)
        {
            
        }
        public string Name => throw new NotImplementedException();

        public int EnergyRequired => throw new NotImplementedException();

        public void GetColored()
        {
            throw new NotImplementedException();
        }

        public bool IsDone()
        {
            throw new NotImplementedException();
        }
    }
}
