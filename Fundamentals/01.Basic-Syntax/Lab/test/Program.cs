using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    class Program
    {
        static void Main(string[] args)
        {
            var day = Console.ReadLine().ToLower();
            var age = int.Parse(Console.ReadLine());
            var price = 0;

            switch (day)
            {
                case "weekday":
                    if (age < 0)
                    {
                        price = 0;
                    }

                    else if (age <= 18)
                    {
                        price += 12;
                    }
                    else if (age <= 64)
                    {
                        price += 18;
                    }
                    else if (age <= 122)
                    {
                        price += 12;
                    }
                    break;
                case "weekend":
                    if (age < 0)
                    {
                        price = 0;
                    }
                    else if (age <= 18)
                    {
                        price += 15;
                    }
                    else if (age <= 64)
                    {
                        price += 20;
                    }
                    else if (age <= 122)
                    {
                        price += 15;
                    }
                
                    break;
                case "holiday":
                    if (age < 0)
                    {
                        price = 0;
                    }
                    else if (age <= 18)
                    {
                        price += 5;
                    }
                    else if (age <= 64)
                    {
                        price += 12;
                    }
                    else if (age <= 122)
                    {
                        price += 10;
                    }
                   
                    break;


            }
            if (price != 0)
            {
                Console.WriteLine($"{price}$");
            }
            else
            {
                Console.WriteLine("Error!");
            }
            Console.ReadLine();
        }
    }
}