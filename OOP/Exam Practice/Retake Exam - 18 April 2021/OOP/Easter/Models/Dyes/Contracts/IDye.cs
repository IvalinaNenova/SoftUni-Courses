namespace Easter.Models.Dyes.Contracts
{
    public interface IDye
    {
        int Power { get; }

        void Use();

        bool IsFinished();
    }
}
