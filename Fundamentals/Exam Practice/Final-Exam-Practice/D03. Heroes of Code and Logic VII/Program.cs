using System;
using System.Collections.Generic;

namespace D03._Heroes_of_Code_and_Logic_VII
{
    class Hero
    {
        public Hero(string name, int hp, int mp)
        {
            Name = name;
            HP = hp;
            MP = mp;
        }
        public string Name { get; set; }
        public int HP { get; set; }
        public int MP { get; set; }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            const int maxHp = 100;
            const int maxMp = 200;

            Dictionary<string, Hero> heroes = new Dictionary<string, Hero>();

            int numberOfHeros = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfHeros; i++)
            {
                string[] heroData = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string heroName = heroData[0];
                int heroHP = int.Parse(heroData[1]);
                int heroMP = int.Parse(heroData[2]);

                heroes.Add(heroName, new Hero(heroName, heroHP, heroMP));
            }

            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] commands = input.Split(" - ");
                string action = commands[0];
                string hero = commands[1];

                if (action == "CastSpell")
                {
                    int mpNeeded = int.Parse(commands[2]);
                    string spellName = commands[3];

                    if (heroes[hero].MP >= mpNeeded)
                    {
                        heroes[hero].MP -= mpNeeded;
                        Console.WriteLine($"{hero} has successfully cast {spellName} and now has {heroes[hero].MP} MP!");
                    }
                    else
                    {
                        Console.WriteLine($"{hero} does not have enough MP to cast {spellName}!");
                    }
                }
                else if (action == "TakeDamage")
                {
                    int damage = int.Parse(commands[2]);
                    string attacker = commands[3];

                    heroes[hero].HP -= damage;
                    if (heroes[hero].HP > 0)
                    {
                        Console.WriteLine($"{hero} was hit for {damage} HP by {attacker} and now has {heroes[hero].HP} HP left!");
                    }
                    else
                    {
                        heroes.Remove(hero);
                        Console.WriteLine($"{hero} has been killed by {attacker}!");
                    }
                }
                else if (action == "Recharge")
                {
                    int rechargeAmount = int.Parse(commands[2]);

                    if (heroes[hero].MP + rechargeAmount > maxMp)
                    {
                        rechargeAmount = maxMp - heroes[hero].MP;
                    }

                    heroes[hero].MP += rechargeAmount;
                    Console.WriteLine($"{hero} recharged for {rechargeAmount} MP!");
                }
                else if (action == "Heal")
                {
                    int healAmount = int.Parse(commands[2]);

                    if (heroes[hero].HP + healAmount > maxHp)
                    {
                        healAmount = maxHp - heroes[hero].HP;
                    }

                    heroes[hero].HP += healAmount;
                    Console.WriteLine($"{hero} healed for {healAmount} HP!");
                }

                input = Console.ReadLine();
            }

            foreach (var hero in heroes)
            {
                Console.WriteLine($"{hero.Key}\n  HP: {hero.Value.HP}\n  MP: {hero.Value.MP}");
            }
        }
    }
}
