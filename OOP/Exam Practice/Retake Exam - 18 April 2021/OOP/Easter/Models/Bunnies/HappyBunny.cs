using System;
using System.Collections.Generic;
using System.Text;

namespace Easter.Models.Bunnies
{
    public class HappyBunny : Bunny
    {
        public HappyBunny(string name) 
            : base(name, 100)
        {
        }

        public override void Work()
        {
            throw new NotImplementedException();
        }
    }
}
