using System;
using System.Collections.Generic;
using System.Text;

namespace _01.GenericBoxOfString
{
    public class Box<T>
    {
        public string Value { get; set; }

        public override string ToString()
        {
            return $"{Value.GetType()}: {Value}";
        }
    }
}
