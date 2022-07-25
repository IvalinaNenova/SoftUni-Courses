using Heroes.Models.Contracts;
using System;

namespace Heroes.Models.Heroes
{
    public abstract class Hero : IHero
    {
        private string name;
        private int health;
        private int armour;
        private IWeapon weapon;

        protected Hero(string name, int health, int armour)
        {
            Name = name;
            Health = health;
            Armour = armour;
        }

        public string Name
        {
            get => name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Hero name cannot be null or empty.");
                }

                name = value;
            }
        }

        public int Health
        {
            get => health;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Hero health cannot be below 0.");
                }
                health = value;
            }
        }

        public int Armour
        {
            get => armour;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Hero armour cannot be below 0.");
                }
                armour = value;
            }
        }

        public IWeapon Weapon
        {
            get => weapon;
            set
            {
                if (value == null)
                {
                    throw new ArgumentException("Weapon cannot be null.");
                }

                weapon = value;
            }
        }

        public bool IsAlive => Health > 0;
        public void TakeDamage(int points)
        {
            int leftoverPoints = 0;

            armour -= points;
            if (armour <= 0)
            {
                leftoverPoints = Math.Abs(Armour);
                armour = 0;
            }

            if (leftoverPoints > 0)
            {
                health -= leftoverPoints;

                if (health < 0)
                {
                    health = 0;
                }
            }
        }

        public void AddWeapon(IWeapon weapon)
        {
            this.Weapon = weapon;
        }
    }
}
