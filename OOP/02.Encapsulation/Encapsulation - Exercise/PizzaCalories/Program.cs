using System;

namespace PizzaCalories
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string pizzaName = Console.ReadLine().Split(' ')[1];
                string[] doughInfo = Console.ReadLine().Split(' ');

                Dough dough = new Dough(doughInfo[1], doughInfo[2], double.Parse(doughInfo[3]));
                Pizza pizza = new Pizza(pizzaName, dough);

                string line = Console.ReadLine();

                while (line != "END")
                {
                    string[] toppingInput = line.Split(' ');
                    Topping topping = new Topping(toppingInput[1], double.Parse(toppingInput[2]));

                    pizza.AddToppings(topping);

                    line = Console.ReadLine();
                }

                Console.WriteLine($"{pizzaName} - {pizza.GetTotalCalories():f2} Calories.");
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
    }
}
