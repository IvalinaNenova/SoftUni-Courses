using System;
using System.Collections.Generic;
using System.Linq;

namespace FoodShortage
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Dictionary<string, IBuyer> buyerList = new Dictionary<string, IBuyer>();

            int numberOfPeople = int.Parse(Console.ReadLine());

            IBuyer buyer = null;

            for (int i = 0; i < numberOfPeople; i++)
            {
                string[] buyerData = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string name = buyerData[0];

                switch (buyerData.Length)
                {
                    case 4:
                    {
                        int age = int.Parse(buyerData[1]);
                        string id = buyerData[2];
                        string birthday = buyerData[3];

                        buyer = new Citizen(name, age, id, birthday);
                        break;
                    }
                    case 3:
                    {
                        int age = int.Parse(buyerData[1]);
                        string group = buyerData[2];

                        buyer = new Rebel(name, age, group);
                        break;
                    }
                }

                buyerList[name] = buyer;
            }

            string buyerName = Console.ReadLine();

            while (buyerName != "End")
            {
                if (buyerList.ContainsKey(buyerName))
                {
                    buyerList[buyerName].BuyFood();
                }

                buyerName = Console.ReadLine();
            }

            int totalFoodBought = buyerList.Values.Sum(x => x.Food);

            Console.WriteLine(totalFoodBought);
        }
    }
}
