using System;
using System.Collections.Generic;
using System.Text;
using Bakery.Utilities.Enums;

namespace Bakery.Models.Drinks
{
    public class Tea : Drink
    {
        private const decimal TeaPrice = 2.50m;
        private DrinkType type;
        public Tea(string name, int portion, string brand) 
            : base(name, portion, TeaPrice, brand)
        {
            type = DrinkType.Tea;
        }
    }
}
