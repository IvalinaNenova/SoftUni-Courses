namespace CarRacing.Models.Racers.Contracts
{
    using Cars.Contracts;

    public interface IRacer
    {
        string Username { get; }

        string RacingBehavior { get; }

        int DrivingExperience { get; }

        ICar Car { get; set; }

        void Race();

        bool IsAvailable();
    }
}
