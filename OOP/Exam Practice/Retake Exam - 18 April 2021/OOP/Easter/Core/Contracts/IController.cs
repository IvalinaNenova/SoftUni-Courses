namespace Easter.Core.Contracts
{
    public interface IController
    {
        string AddBunny(string bunnyType, string bunnyName);

        string AddDyeToBunny(string bunnyName, int power);

        string AddEgg(string eggName, int energyRequired);

        string ColorEgg(string eggName);

        string Report();
    }
}
