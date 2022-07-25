using System;
using System.Collections.Generic;
using System.Text;

namespace Heroes.Models.Weapons
{
    public class Claymore : Weapon
    {
        public Claymore(string name, int durability) 
            : base(name, durability)
        {
        }

        public override int DoDamage()
        {
            if (Durability > 0)
            {
                this.Durability--;

                return 20;
            }

            return 0;
        }
    }
}
