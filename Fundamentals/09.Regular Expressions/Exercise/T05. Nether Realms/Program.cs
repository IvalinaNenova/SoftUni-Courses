using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace T05._Nether_Realms
{
    class Daemon
    {
        public Daemon(string name, int health, double damage)
        {
            Name = name;
            Health = health;
            Damage = damage;
        }
        public string Name { get; set; }
        public int Health { get; set; }
        public double Damage { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            string lettersPattern = @"[^0-9+\-*\/\.]";
            string digitPattern = @"[+|-]?\d+\.?\d*";
            string multiplyAndDividePattern = @"[*/]";
            string splitPattern = @"[\s]*[,]{1}[\s]*";


            string input = Console.ReadLine();
            string[] daemons = Regex.Split(input, splitPattern).ToArray();

            List<Daemon> daemonList = new List<Daemon>();

            foreach (string daemon in daemons)
            {
                int health = GetHealth(daemon, lettersPattern);
                double damage = GetDamage(daemon, digitPattern, multiplyAndDividePattern);

                daemonList.Add(new Daemon(daemon, health, damage));
            }

            foreach (Daemon daemon in daemonList.OrderBy(x => x.Name))
            {
                Console.WriteLine($"{daemon.Name} - {daemon.Health} health, {daemon.Damage:f2} damage");
            }
        }

        private static double GetDamage(string daemon, string digitPattern, string multiplyAndDividePattern)
        {
            var digitMatches = Regex.Matches(daemon, digitPattern).ToArray();
            double damage = 0;

            foreach (var number in digitMatches)
            {
                damage += double.Parse(number.Value);
            }

            var operationsMatches = Regex.Matches(daemon, multiplyAndDividePattern).ToArray();

            foreach (var operation in operationsMatches)
            {
                if (operation.Value == "*")
                {
                    damage *= 2;
                }
                else if (operation.Value == "/")
                {
                    damage /= 2;
                }
            }

            return damage;
        }

        private static int GetHealth(string daemon, string lettersPattern)
        {
            var letterMatches = Regex.Matches(daemon, lettersPattern).ToArray();
            int health = 0;

            foreach (var letter in letterMatches)
            {
                health += char.Parse(letter.Value);
            }

            return health;
        }
    }
}
