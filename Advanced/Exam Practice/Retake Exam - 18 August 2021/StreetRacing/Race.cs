using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace StreetRacing
{
    public class Race
    {
        //•	Name: string
        //•	Type: string
        //•	Laps: int
        //•	Capacity: int - the maximum allowed number of participants in the race
        //•	MaxHorsePower: int - the maximum allowed Horse Power of a Car in the Race
        private List<Car> participants;
        public string Name { get; set; }

        public string Type { get; set; }

        public int Laps { get; set; }

        public int Capacity { get; set; }

        public int MaxHorsePower { get; set; }

        public List<Car> Participants
        {
            get => participants;
            set => participants = value;
        }
        public int Count => Participants.Count;
        public Race(string name, string type, int laps, int capacity, int maxHorsePower)
        {
            Name = name;
            Type = type;
            Laps = laps;
            Capacity = capacity;
            MaxHorsePower = maxHorsePower;
            Participants = new List<Car>();
        }
        //The constructor of the Race class should receive name, type, laps, capacity and maxHorsePower.

        public void Add(Car car)
        {
            Car duplicateCar = Participants.FirstOrDefault(c => c.LicensePlate.Equals(car.LicensePlate));
            if (duplicateCar == null &&
                Count < Capacity &&
                car.HorsePower <= MaxHorsePower)
            {
                Participants.Add(car);
            }
        } /*- adds the entity if there isn't a Car with the same License plate and if there is enough space in terms of race capacity and if the car meets the maximum horse power requirment of the race.*/

        public  bool Remove(string licensePlate)
        {
            return participants.Remove(participants.Find(c => c.LicensePlate == licensePlate));
        }/*- removes a Car from the race with the given License plate, if such exists and returns bool if the deletion is successful.*/

        public Car FindParticipant(string licensePlate)
        {
            Car searchedCar = Participants.FirstOrDefault(car => car.LicensePlate == licensePlate);
            if (searchedCar == null)
            {
                return null;
            }
            return searchedCar;
        }/*- returns a Car with the given License plate.If it doesn't exist, return null.*/

        public Car GetMostPowerfulCar()
        {
            if (participants.Count > 0)
            {
                int fastest = int.MinValue;
                foreach (var car in participants)
                {
                    if (car.HorsePower > fastest)
                    {
                        fastest = car.HorsePower;
                    }
                }

                return participants.Find(car => car.HorsePower == fastest);
            }

            return null;
        }/*– returns the Car with most HorsePower.If there are no Cars in the Race, method should return null. */

        public string Report()
        {
            StringBuilder output = new StringBuilder();
            output.AppendLine($"Race: {Name} - Type: {Type} (Laps: {Laps})");
            for (int i = 0; i < participants.Count -1; i++)
            {
                output.AppendLine(participants[i].ToString());
            }
            output.Append(participants[Count - 1].ToString());
            return output.ToString();
        }/*- returns information about the Race and the Cars participating it in the following format:*/
        //"Race: {Name} - Type: {Type} (Laps: {Laps})
        //{Car1
        //}
        //{Car2
        //}
        //… "

    }
}
