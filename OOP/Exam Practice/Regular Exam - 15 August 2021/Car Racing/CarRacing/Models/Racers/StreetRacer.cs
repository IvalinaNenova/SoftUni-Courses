using System;
using System.Collections.Generic;
using System.Text;
using CarRacing.Models.Cars.Contracts;

namespace CarRacing.Models.Racers
{
    public class StreetRacer : Racer
    {
        public StreetRacer(string username, ICar car) 
            : base(username, "aggressive", 10, car)
        {
        }
    }
}
