using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gym.Models.Athletes.Contracts;
using Gym.Models.Equipment.Contracts;
using Gym.Models.Gyms.Contracts;
using Gym.Utilities.Messages;

namespace Gym.Models.Gyms
{
    public abstract class Gym : IGym
    {
        private string name;
        private int capacity;
        private  ICollection<IEquipment> equipment;
        private  ICollection<IAthlete> athletes;

        protected Gym(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            equipment = new List<IEquipment>();
            athletes = new List<IAthlete>();
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidGymName);
                }

                name = value;
            }
        }

        public int Capacity
        {
            get => capacity;
            set => capacity = value;
        }

        public double EquipmentWeight
        {
            get { return equipment.Sum(e => e.Weight); }
        }

        public ICollection<IEquipment> Equipment => equipment;

        public ICollection<IAthlete> Athletes => athletes;

        public void AddAthlete(IAthlete athlete)
        {
            if (athletes.Count == Capacity)
            {
                throw new InvalidOperationException(ExceptionMessages.NotEnoughSize);
            }

            athletes.Add(athlete);
        }

        public bool RemoveAthlete(IAthlete athlete)
        {
            return athletes.Remove(athlete);
        }

        public void AddEquipment(IEquipment equipment)
        {
            this.equipment.Add(equipment);
        }

        public void Exercise()
        {
            foreach (var athlete in athletes)
            {
                athlete.Exercise();
            }
        }

        public string GymInfo()
        {
            string athletesAsString = athletes.Count == 0 ? "No athletes" : string.Join(", ", athletes.Select(a=>a.FullName));

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{Name} is a {this.GetType().Name}:");
            sb.AppendLine($"Athletes: {athletesAsString}");
            sb.AppendLine($"Equipment total count: {equipment.Count}");
            sb.AppendLine($"Equipment total weight: {EquipmentWeight:f2} grams");
           
            return sb.ToString().TrimEnd();
        }
    }
}
