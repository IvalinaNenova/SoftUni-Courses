using Heroes.Core.Contracts;
using Heroes.Models.Contracts;
using Heroes.Models.Heroes;
using Heroes.Models.Weapons;
using Heroes.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Heroes.Models.Map;

namespace Heroes.Core
{
    public class Controller : IController
    {
        private HeroRepository heroes;
        private WeaponRepository weapons;

        public Controller()
        {
            heroes = new HeroRepository();
            weapons = new WeaponRepository();
        }
        public string CreateWeapon(string type, string name, int durability)
        {
            IWeapon weapon = null;
            if (type == "Mace")
            {
                weapon = new Mace(name, durability);
            }
            else if (type == "Claymore")
            {
                weapon = new Claymore(name, durability);
            }
            else
            {
                throw new InvalidOperationException("Invalid weapon type.");
            }

            var existingWeapon = weapons.Models.FirstOrDefault(w => w.Name == name);

            if (existingWeapon != null)
            {
                throw new InvalidOperationException($"The weapon { name } already exists.");
            }

            weapons.Add(weapon);

            return $"A {type.ToLower()} {name} is added to the collection.";
        }

        public string CreateHero(string type, string name, int health, int armour)
        {
            IHero hero = null;

            if (type == "Knight")
            {
                hero = new Knight(name, health, armour);
            }
            else if (type == "Barbarian")
            {
                hero = new Barbarian(name, health, armour);
            }
            else
            {
                throw new InvalidOperationException("Invalid hero type.");
            }


            if (heroes.FindByName(name) != null)
            {
                throw new InvalidOperationException($"The hero {name} already exists.");
            }

            heroes.Add(hero);

            return hero.GetType().Name == "Knight" 
                ? $"Successfully added Sir {name} to the collection." 
                : $"Successfully added Barbarian {name} to the collection.";
        }

        public string AddWeaponToHero(string weaponName, string heroName)
        {
            var existingHero = heroes.FindByName(heroName);
            var existingWeapon = weapons.FindByName(weaponName);
            if (existingHero == null)
            {
                throw new InvalidOperationException($"Hero {heroName} does not exist.");
            }

            if (existingWeapon == null)
            {
                throw new InvalidOperationException($"Weapon { weaponName } does not exist.");
            }

            if (existingHero.Weapon != null)
            {
                throw new InvalidOperationException($"Hero {heroName} is well-armed.");
            }

            existingHero.AddWeapon(existingWeapon);
            weapons.Remove(existingWeapon);

            return $"Hero {heroName} can participate in battle using a {existingWeapon.GetType().Name.ToLower()}.";
        }

        public string StartBattle()
        {
            Map map = new Map();

            List<IHero> participants = heroes.Models.Where(h => h.IsAlive && h.Weapon != null).ToList();
            return map.Fight(participants);
        }

        public string HeroReport()
        {
            var orderedHeroes = heroes.Models.OrderBy(h => h.GetType().Name)
                .ThenByDescending(h => h.Health)
                .ThenBy(h => h.Name);

            StringBuilder sb = new StringBuilder();

            foreach (var hero in orderedHeroes)
            {
                string weaponName = string.Empty;

                weaponName = hero.Weapon == null 
                    ? "Unarmed" 
                    : hero.Weapon.Name;

                sb.AppendLine($"{hero.GetType().Name}: {hero.Name}");
                sb.AppendLine($"--Health: {hero.Health }");
                sb.AppendLine($"--Armour: {hero.Armour }");
                sb.AppendLine($"--Weapon: {weaponName }");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
