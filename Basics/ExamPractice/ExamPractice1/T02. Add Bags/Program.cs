using System;

namespace T02._Add_Bags
{
    class Program
    {
        static void Main(string[] args)
        {
            //            1.Цената на багаж над 20кг - реално число в диапазона[10.0…80.0]
            //2.Килограми на багажа – реално число в диапазона[1.0…32.0]
            //3.Дни до пътуването – цяло число в диапазона[1…60]
            //4.Брой багажи – цяло число в диапазона[1…10]
            double over20kgPrice = double.Parse(Console.ReadLine());
            double killos = double.Parse(Console.ReadLine());
            int daysUntilTravel = int.Parse(Console.ReadLine());
            int numberOfBags = int.Parse(Console.ReadLine());
            double price = 0;

            if (killos < 10)
            {
                price = over20kgPrice * 0.2;
            }
            else if (killos <= 20)
            {
                price = over20kgPrice / 2;
            }
            else
            {
                price = over20kgPrice;
            }
            if (daysUntilTravel < 7)
            {
                price *= 1.4;
            }
            else if (daysUntilTravel <= 30)
            {
                price *= 1.15;
            }
            else
            {
                price *= 1.1;
            }

            double totalPrice = numberOfBags * price;

            Console.WriteLine($"The total price of bags is: {totalPrice:f2} lv. ");
        }
    }
}
