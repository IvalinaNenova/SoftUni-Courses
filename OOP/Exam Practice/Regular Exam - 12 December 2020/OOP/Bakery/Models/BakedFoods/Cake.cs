using System;
using System.Collections.Generic;
using System.Text;
using Bakery.Utilities.Enums;

namespace Bakery.Models.BakedFoods
{
    public class Cake : BakedFood
    {
        private const int InitialCakePortion = 245;
        private BakedFoodType type;
        public Cake(string name, decimal price) 
            : base(name, InitialCakePortion, price)
        {
            type = BakedFoodType.Cake;
        }
    }
}
