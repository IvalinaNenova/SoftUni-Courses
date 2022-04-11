using System;

namespace S04._Easter_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            int quantity = int.Parse(Console.ReadLine());
            string fillOrBuy = Console.ReadLine();
            int eggsSold = 0;

            while (fillOrBuy != "Close")
            {
                int numberOfeggs = int.Parse(Console.ReadLine());
                
                if (quantity < numberOfeggs && fillOrBuy == "Buy")
                {
                    Console.WriteLine("Not enough eggs in store!");
                    Console.WriteLine($"You can buy only {quantity}.");
                    break;
                }
                if (fillOrBuy == "Fill")
                {
                    quantity+=numberOfeggs;
                }
                else if (fillOrBuy == "Buy")
                {
                    quantity-=numberOfeggs;
                    eggsSold += numberOfeggs;
                }
                fillOrBuy = Console.ReadLine();
            }
            if (fillOrBuy == "Close")
            {
            Console.WriteLine("Store is closed!");
            Console.WriteLine($"{eggsSold} eggs sold.");
            }
        }
    }
}
