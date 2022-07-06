using MilitaryElite.Interfaces;

namespace MilitaryElite.Classes
{
    public class Repair : IRepair
    {
        public Repair(string partName, int hoursWorked)
        {
            PartName = partName;
            HoursWorked = hoursWorked;
        }
        public string PartName { get; set; }
        public int HoursWorked { get; set; }

        public override string ToString()
        {
            return $"Part Name: {PartName} Hours Worked: {HoursWorked}";
        }
    }
}
