using System;
using System.Collections.Generic;
using System.Text;
using Easter.Models.Bunnies.Contracts;
using Easter.Models.Eggs.Contracts;
using Easter.Models.Workshops.Contracts;

namespace Easter.Models.Workshops
{
    public class Workshop : IWorkshop
    {
        public Workshop()
        {
            
        }
        public void Color(IEgg egg, IBunny bunny)
        {
            throw new NotImplementedException();
        }
    }
}
