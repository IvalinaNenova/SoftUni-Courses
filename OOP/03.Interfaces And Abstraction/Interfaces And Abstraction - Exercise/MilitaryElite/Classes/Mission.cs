using MilitaryElite.Interfaces;

namespace MilitaryElite.Classes
{
    public class Mission : IMission
    {
        public Mission(string codeName, Status status)
        {
            CodeName = codeName;
            Status = status;
        }
        public string CodeName { get; set; }
        public Status Status { get; set; }
        public void CompleteMission(string codeName)
        {

        }

        public override string ToString()
        {
            return $"Code Name: {CodeName} State: {Status}";
        }
    }
}
