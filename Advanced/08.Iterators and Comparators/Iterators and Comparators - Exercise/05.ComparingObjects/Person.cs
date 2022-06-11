using System;
using System.Collections.Generic;
using System.Text;

namespace _05.ComparingObjects
{
    public class Person : IComparable<Person>
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Town { get; set; }

        public Person(string name, int age, string town)
        {
            Name = name;
            Age = age;
            Town = town;
        }

        public int CompareTo(Person other)
        {
            int result = Name.CompareTo(other.Name);

            if (result != 0)
            {
                return result;
            }

            result = this.Age.CompareTo(other.Age);
            if (result != 0)
            {
                return result;
            }

            return this.Town.CompareTo(other.Town);
        }
    }
}
