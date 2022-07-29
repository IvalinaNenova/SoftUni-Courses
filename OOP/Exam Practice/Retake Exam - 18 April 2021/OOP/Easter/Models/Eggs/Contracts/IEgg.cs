namespace Easter.Models.Eggs.Contracts
{
    public interface IEgg
    {
        string Name { get; }

        int EnergyRequired { get; }

        void GetColored();

        bool IsDone();
    }
}
