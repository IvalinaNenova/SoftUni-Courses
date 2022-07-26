using System;
using System.Collections.Generic;
using System.Text;
using Gym.Models.Equipment.Contracts;

namespace Gym.Models.Equipment
{
    public abstract class Equipment : IEquipment
    {

        protected Equipment(double weight, decimal price)
        {
            Weight = weight;
            Price = price;
        }
        public double Weight { get; private set; }

        public decimal Price { get; private set; }
    }
}
