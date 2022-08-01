using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WarCroft.Constants;
using WarCroft.Entities.Characters;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Items;

namespace WarCroft.Core
{
	public class WarController
    {
        private List<Character> characters;
		private List<Item> items;
		public WarController()
		{
			characters = new List<Character>();
			items = new List<Item>();
		}

		public string JoinParty(string[] args)
        {
            string type = args[0];
			string characterName = args[1];

			Character character;
            switch (type)
            {
                case "Warrior":
                    character = new Warrior(characterName);
                    break;
                case "Priest":
                    character = new Priest(characterName);
                    break;
                default:
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidCharacterType, type));
            }

			characters.Add(character);
            return string.Format(SuccessMessages.JoinParty, characterName);
        }

		public string AddItemToPool(string[] args)
        {
            string itemName = args[0];

            Item item = null;

            switch (itemName)
            {
                case "FirePotion":
                    item = new FirePotion();
                    break;
                case "HealthPotion":
                    item = new HealthPotion();
                    break;
                default:
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidItem, itemName));
            }

			items.Add(item);
			return string.Format(SuccessMessages.AddItemToPool, itemName);
        }

		public string PickUpItem(string[] args)
        {
            string characterName = args[0];

            var targetCharacter = characters.FirstOrDefault(c => c.Name == characterName);

            if (targetCharacter == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, characterName));
            }

            if (!items.Any())
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.ItemPoolEmpty));
            }

            var item = items.Last();
            targetCharacter.Bag.AddItem(item);

            items.RemoveAt(items.Count-1);

            return string.Format(SuccessMessages.PickUpItem, characterName, item.GetType().Name);
        }

		public string UseItem(string[] args)
        {
            string characterName = args[0];
            string itemName = args[1];

            var targetCharacter = characters.FirstOrDefault(c => c.Name == characterName);

            if (targetCharacter == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, characterName));
            }

            var item = targetCharacter.Bag.GetItem(itemName);
            targetCharacter.UseItem(item);

            return string.Format(SuccessMessages.UsedItem, characterName, itemName);
        }

		public string GetStats()
        {
            var ordered = characters
                .OrderByDescending(c => c.IsAlive)
                .ThenByDescending(c => c.Health);

            StringBuilder sb = new StringBuilder();

            foreach (var character in ordered)
            {
                string lifeStatus = character.IsAlive == true ? "Alive" : "Dead";
                sb.AppendLine(
                    $"{character.Name} - HP: {character.Health}/{character.BaseHealth}, AP: {character.Armor}/{character.BaseArmor}, Status: {lifeStatus}");
            }

            return sb.ToString().TrimEnd();
        }

		public string Attack(string[] args)
		{
			string attackerName = args[0];
            string defenderName = args[1];

            var attacker = characters.FirstOrDefault(c => c.Name == attackerName);
            var defender = characters.FirstOrDefault(c => c.Name == defenderName);

            if (attacker == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, attackerName));
            }

            if (defender == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, defenderName));
            }

            if (attacker.GetType().Name == "Priest")
            {
                throw new ArgumentException(string.Format(ExceptionMessages.AttackFail, attackerName));
            }

            Warrior warrior = attacker as Warrior;
            warrior.Attack(defender);

            StringBuilder sb = new StringBuilder();

            sb.AppendLine(string.Format(SuccessMessages.AttackCharacter, attackerName, defenderName,
                attacker.AbilityPoints, defenderName, defender.Health, defender.BaseHealth, defender.Armor,
                defender.BaseArmor));

            if (defender.IsAlive == false)
            {
                sb.AppendLine(string.Format(SuccessMessages.AttackKillsCharacter, defenderName));
            }

            return sb.ToString().TrimEnd();
        }

		public string Heal(string[] args)
        {
            string healerName = args[0];
            string healingReceiverName = args[1];

            var targetHealer = characters.FirstOrDefault(c => c.Name == healerName);
            var targetToHeal = characters.FirstOrDefault(c => c.Name == healingReceiverName);

            if (targetHealer == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, healerName));
            }

            if (targetToHeal == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, healingReceiverName));
            }

            if (targetHealer.GetType().Name == "Warrior")
            {
                throw new ArgumentException(string.Format(ExceptionMessages.HealerCannotHeal, healerName));
            }

            Priest healer = targetHealer as Priest;
            healer.Heal(targetToHeal);

            return string.Format(SuccessMessages.HealCharacter, healerName, healingReceiverName, healer.AbilityPoints,
                healingReceiverName, targetToHeal.Health);
        }
	}
}
