using System;
using System.Collections.Generic;
using System.Linq;

namespace BirthdayCelebrations
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<IBirthable> bornList = new List<IBirthable>();
            IBirthable born = null;

            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] commands = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string lifeForm = commands[0];

                switch (lifeForm)
                {
                    case "Citizen":
                    {
                        string name = commands[1];
                        int age = int.Parse(commands[2]);
                        string id = commands[3];
                        string birthday = commands[4];

                        born = new Citizen(name, age, id, birthday);
                        break;
                    }
                    case "Pet":
                    {
                        string name = commands[1];
                        string birthday = commands[2];

                        born = new Pet(name, birthday);
                        break;
                    }
                    case "Robot":
                        input = Console.ReadLine();
                        continue;
                }

                bornList.Add(born);

                input = Console.ReadLine();
            }

            string yearToLookFor = Console.ReadLine();

            List<string> birthdays = bornList
                .Where(x=> x.Birthday.EndsWith(yearToLookFor))
                .Select(x=>x.Birthday)
                .ToList();

            Console.WriteLine(string.Join(Environment.NewLine, birthdays));
        }
    }
}
