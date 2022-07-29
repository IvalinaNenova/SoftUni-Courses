namespace Easter.Models.Workshops.Contracts
{
    using Bunnies.Contracts;
    using Eggs.Contracts;

    public interface IWorkshop
    {
        void Color(IEgg egg, IBunny bunny);
    }
}
