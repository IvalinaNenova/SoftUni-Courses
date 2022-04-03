using System;
using System.Collections.Generic;

namespace Exam_Problem_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> guestList = new Dictionary<string, List<string>>();
            int countOfDislikedMeals = 0;

            string input = Console.ReadLine();

            while (input != "Stop")
            {
                string[] guestData = input.Split("-");
                string guestOpinion = guestData[0];
                string guestName = guestData[1];
                string meal = guestData[2];

                if (guestOpinion == "Like")
                {
                    if (!guestList.ContainsKey(guestName))
                    {
                        guestList.Add(guestName, new List<string>{});
                    }

                    if (!guestList[guestName].Contains(meal))
                    {
                        guestList[guestName].Add(meal);
                    }
                    
                }
                else if (guestOpinion == "Dislike")
                {
                    if (!guestList.ContainsKey(guestName))
                    {
                        Console.WriteLine($"{guestName} is not at the party.");
                    }
                    else if (!guestList[guestName].Contains(meal))
                    {
                        Console.WriteLine($"{guestName} doesn't have the {meal} in his/her collection.");
                    }
                    else
                    {
                        guestList[guestName].Remove(meal);
                        Console.WriteLine($"{guestName} doesn't like the {meal}.");
                        countOfDislikedMeals++;
                    }
                }

                input = Console.ReadLine();
            }

            foreach (var guest in guestList)
            {
                Console.WriteLine($"{guest.Key}: {string.Join(", ", guest.Value)}");
            }

            Console.WriteLine($"Unliked meals: {countOfDislikedMeals}");
        }
    }
}
