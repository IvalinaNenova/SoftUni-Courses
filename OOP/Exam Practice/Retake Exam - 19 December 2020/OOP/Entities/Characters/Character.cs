using System;

using WarCroft.Constants;
using WarCroft.Entities.Inventory;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Characters.Contracts
{
    public abstract class Character
    {
        private string name;
        private double baseHealth;
        private double health;
        private double baseArmor;
        private double armor;
        private  double abilityPoints;
        private Bag bag;

        // TODO: Implement the rest of the class.
        protected Character(string name, double health, double armor, double abilityPoints, Bag bag)
        {
            Name = name;
            BaseHealth = health;
            Health = BaseHealth;
            BaseArmor = armor;
            Armor = BaseArmor;
            AbilityPoints = abilityPoints;
            Bag = bag;
        }

        public string Name
        {
			get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.CharacterNameInvalid);
                }

                name = value;
            }
        }

        public double BaseHealth
        {
            get => baseHealth;
            private set => baseHealth = value;
        }

        public double Health
        {
            get => health;
            protected internal set
            {
                if (value < 0)
                {
                    value = 0;
                }

                if (value > baseHealth)
                {
                    value = baseHealth;
                }

                health = value;
            }
        }

        public double BaseArmor
        {
            get => baseArmor;
            private set => baseArmor = value;
        }

        public double Armor
        {
            get => armor;
            private set
            {
                if (value < 0)
                {
                    value = 0;
                }

                if (value > baseArmor)
                {
                    value = baseArmor;
                }

                armor = value;
            }
        }

        public double AbilityPoints
        {
            get => abilityPoints;
            private set => abilityPoints = value;
        }

        public Bag Bag
        {
            get => bag;
            private set => bag = value;
        }

        public bool IsAlive { get; set; } = true;
        public void TakeDamage(double hitPoints)
        {
            EnsureAlive();
            double leftoverHitPoints = 0;

            if (this.Armor - hitPoints < 0)
            {
                leftoverHitPoints = this.Armor - hitPoints;
            }
            this.Armor -= hitPoints;
            this.Health -= Math.Abs(leftoverHitPoints);

            if (this.Health == 0)
            {
                this.IsAlive = false;
            }
        }

        public void UseItem(Item item)
        {
            EnsureAlive();
            item.AffectCharacter(this);
        }
        protected internal void EnsureAlive()
		{
			if (!this.IsAlive)
			{
				throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
			}
		}
    }
}