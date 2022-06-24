using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _06.EqualityLogic 
{
    public class Person : IComparable<Person>
    {
        private string name;
        private int age;

        public Person(string name, int age)
        {
            this.name = name.ToLower();
            this.age = age;
        }

        public string Name
        {
            get => name;
            set => name = value;
        }
        public int Age
        {
            get => age;
            set => age = value;
        }

        public int CompareTo(Person other)
        {
            var comparison = String.Compare(this.Name, other.Name, StringComparison.Ordinal);

            return comparison == 0
                ? this.Age.CompareTo(other.Age)
                : comparison;
        }

        public override bool Equals(object other)
        {
            var y = other as Person;
            return this.Name == y.Name && this.Age == y.Age;
        }

        public override int GetHashCode()
        {
            var hashCode = this.Name.Length * 10000;
            hashCode = this.Name.Aggregate(hashCode, (current, letter) => current + letter);
            hashCode += this.Age * 10000;

            return hashCode;
        }
    }
}
