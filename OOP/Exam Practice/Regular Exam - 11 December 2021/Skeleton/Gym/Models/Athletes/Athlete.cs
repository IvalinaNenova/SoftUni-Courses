using System;
using System.Collections.Generic;
using System.Text;
using Gym.Models.Athletes.Contracts;
using Gym.Utilities.Messages;

namespace Gym.Models.Athletes
{
    public abstract class Athlete : IAthlete
    {
        private string fullName;
        private string motivation;
        private int stamina;
        private int numberOfMedals;

        protected Athlete(string fullName, string motivation, int numberOfMedals, int stamina)
        {
            FullName = fullName;
            Motivation = motivation;
            NumberOfMedals = numberOfMedals;
            Stamina = stamina;
        }

        public string FullName
        {
            get => fullName;
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidAthleteName);
                }

                fullName = value;
            }
        }

        public string Motivation
        {
            get=> motivation;
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidAthleteMotivation);
                }

                motivation = value;
            }
        }

        public int Stamina
        {
            get => stamina;
            set => stamina = value;
        }

        public int NumberOfMedals
        {
            get => numberOfMedals;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidAthleteMedals);
                }

                numberOfMedals = value;
            }
        }

        public abstract void Exercise();
    }
}
