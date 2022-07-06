using MilitaryElite.Interfaces;

namespace MilitaryElite.Classes
{
    public abstract class Soldier : ISoldier
    {
        protected Soldier(string id, string firstName, string lastName)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
        }
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

    }
}
