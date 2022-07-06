namespace MilitaryElite.Interfaces
{
    public interface IMission
    {
        public string CodeName { get; set; }

        public Status Status { get; set; }

        void CompleteMission(string codeName);
    }
}
