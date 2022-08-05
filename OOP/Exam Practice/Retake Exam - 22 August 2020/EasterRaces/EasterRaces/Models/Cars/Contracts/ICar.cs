namespace EasterRaces.Models.Cars.Contracts
{
    public interface ICar
    {
        string Model { get; }

        int HorsePower { get; }

        double CubicCentimeters { get; }

        double CalculateRacePoints(int laps);
    }
}
