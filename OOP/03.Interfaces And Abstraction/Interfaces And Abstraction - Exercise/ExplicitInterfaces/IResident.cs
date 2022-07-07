using System;
using System.Collections.Generic;
using System.Text;

namespace ExplicitInterfaces
{
    public interface IResident
    {
        public string Name { get; set; }
        public string Country { get; set; }

        string GetName()
        {
            return $"Mr/Ms/Mrs {this.Name}";
        }
    }
}
