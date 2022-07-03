using System;

namespace FootballTeamGenerator
{
    public class Player
    {
        //endurance, sprint, dribble, passing, and shooting
        private string name;
        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;

        public Player(string name, int endurance, int sprint, int dribble, int passing, int shooting)
        {
            Name = name;
            Endurance = endurance;
            Sprint = sprint;
            Dribble = dribble;
            Passing = passing;
            Shooting = shooting;
        }
        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("A name should not be empty.");
                }
                name = value;
            }
        }
        public int Endurance
        {
            get => endurance;
            private set
            {
                ValidateStatData(nameof(Endurance), value);
                endurance = value;
            }
        }

        public int Sprint
        {
            get => sprint;
            private set
            {
                ValidateStatData(nameof(Sprint), value);
                sprint = value;
            }
        }
        public int Dribble
        {
            get => dribble;
            private set
            {
                ValidateStatData(nameof(Dribble), value);
                dribble = value;
            }
        }
        public int Passing
        {
            get => passing;
            private set
            {
                ValidateStatData(nameof(Passing), value);
                passing = value;
            }
        }
        public int Shooting
        {
            get => shooting;
            private set
            {
                ValidateStatData(nameof(Shooting), value);
                shooting = value;
            }
        }

        public double SkillLevel => (Endurance + Dribble + Passing + Sprint + Shooting) / 5.0;
        private static void ValidateStatData(string statName, int value)
        {
            if (value < 0 || value > 100)
            {
                throw new ArgumentException($"{statName} should be between 0 and 100.");
            }
        }
    }
}
