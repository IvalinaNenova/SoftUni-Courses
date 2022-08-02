using System;
using System.Collections.Generic;
using System.Text;
using Bakery.Utilities.Enums;

namespace Bakery.Models.Drinks
{
    public class Water : Drink
    {
        private const decimal WaterPrice = 1.50m;
        private DrinkType type;
        public Water(string name, int portion, string brand) 
            : base(name, portion, WaterPrice, brand)
        {
            type = DrinkType.Water;
        }
    }
}
