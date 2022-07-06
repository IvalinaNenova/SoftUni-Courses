using MilitaryElite.Interfaces;

namespace MilitaryElite.Classes
{
    public class Private : Soldier, IPrivate
    {
        public Private(string id, string firstName, string lastName, decimal salary)
            : base(id, firstName, lastName)
        {
            this.Salary = salary;
        }
        public override string ToString()
        {
            return $"Name: {FirstName} {LastName} Id: {Id} Salary: {Salary:f2}";
        }

        public decimal Salary { get; set; }
    }
}
