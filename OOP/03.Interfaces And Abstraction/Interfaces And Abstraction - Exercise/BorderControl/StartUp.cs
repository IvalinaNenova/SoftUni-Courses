using System;
using System.Collections.Generic;
using System.Linq;

namespace BorderControl
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<IIdentifiable> populationList = new List<IIdentifiable>();
            IIdentifiable lifeForm;

            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] lifeFormData = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (lifeFormData.Length == 3)
                {
                    string name = lifeFormData[0];
                    int age = int.Parse(lifeFormData[1]);
                    string id = lifeFormData[2];

                    lifeForm = new Citizen(name, age, id);
                }
                else
                {
                    string model = lifeFormData[0];
                    string id = lifeFormData[1];

                    lifeForm = new Robot(model, id);
                }

                populationList.Add(lifeForm);

                input = Console.ReadLine();
            }

            string idToLookFor = Console.ReadLine();

            List<string> fakeIDs = populationList
                .Where(x => x.Id.EndsWith(idToLookFor))
                .Select(x => x.Id)
                .ToList();

            Console.WriteLine(string.Join(Environment.NewLine, fakeIDs));
        }
    }
}
