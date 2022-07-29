using System;
using System.Collections.Generic;
using System.Text;
using Easter.Models.Dyes.Contracts;

namespace Easter.Models.Dyes
{
    public class Dye : IDye
    {
        public Dye(int power)
        {
            
        }
        public int Power => throw new NotImplementedException();

        public void Use()
        {
            throw new NotImplementedException();
        }

        public bool IsFinished()
        {
            throw new NotImplementedException();
        }
    }
}
