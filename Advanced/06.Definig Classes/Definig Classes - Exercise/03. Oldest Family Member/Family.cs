using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class Family
    {
       private List<Person> _familyMembers = new List<Person>();

        public void AddMembers(Person member)
        {
            _familyMembers.Add(member);
        }

        public Person GetOldestMember()
        {
            return _familyMembers.OrderByDescending(person => person.Age).First();
        }
    }
}
