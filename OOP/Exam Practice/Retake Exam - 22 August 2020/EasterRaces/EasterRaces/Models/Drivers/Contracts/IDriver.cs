using EasterRaces.Models.Cars.Contracts;

namespace EasterRaces.Models.Drivers.Contracts
{
    public interface IDriver
    {
        string Name { get; }

        ICar Car { get; }

        int NumberOfWins { get; }

        bool CanParticipate { get; }

        void WinRace();

        void AddCar(ICar car);
    }
}