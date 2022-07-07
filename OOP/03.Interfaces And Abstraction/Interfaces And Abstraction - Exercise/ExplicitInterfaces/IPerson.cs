using System;
using System.Collections.Generic;
using System.Text;

namespace ExplicitInterfaces
{
    public interface IPerson
    {
        public string Name { get; set; }
        public int Age { get; set; }

        string GetName()
        {
            return this.Name;
        }
    }
}
