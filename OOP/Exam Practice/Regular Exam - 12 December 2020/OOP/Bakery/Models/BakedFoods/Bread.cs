using System;
using System.Collections.Generic;
using System.Text;
using Bakery.Utilities.Enums;

namespace Bakery.Models.BakedFoods
{
    public class Bread : BakedFood
    {
        private const int InitialBreadPortion = 200;
        private BakedFoodType type;
        public Bread(string name,  decimal price) 
            : base(name, InitialBreadPortion, price)
        {
            type = BakedFoodType.Bread;
        }
    }
}
