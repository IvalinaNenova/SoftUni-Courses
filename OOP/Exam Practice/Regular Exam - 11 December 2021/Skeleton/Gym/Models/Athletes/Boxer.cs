using System;
using System.Collections.Generic;
using System.Text;
using Gym.Utilities.Messages;

namespace Gym.Models.Athletes
{
    public class Boxer : Athlete
    {
        public Boxer(string fullName, string motivation, int numberOfMedals) 
            : base(fullName, motivation, numberOfMedals, 60)
        {
        }

        public override void Exercise()
        {
            this.Stamina += 15;

            if (this.Stamina > 100)
            {
                this.Stamina = 100;
                throw new ArgumentException(ExceptionMessages.InvalidStamina);
            }
        }
    }
}
