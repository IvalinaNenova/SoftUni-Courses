namespace EasterRaces.Core.Contracts
{
    public interface IChampionshipController
    {
        string CreateDriver(string driverName);

        string CreateCar(string type, string model, int horsePower);

        string CreateRace(string name, int laps);

        string AddDriverToRace(string raceName, string driverName);

        string AddCarToDriver(string driverName, string carModel);

        string StartRace(string raceName);
    }
}
