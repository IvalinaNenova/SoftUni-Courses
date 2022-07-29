using System;
using System.Collections.Generic;
using System.Text;

namespace AquaShop.Models.Aquariums
{
    public class SaltwaterAquarium : Aquarium
    {
        public SaltwaterAquarium(string name) 
            : base(name, 25)
        {
        }
    }
}
