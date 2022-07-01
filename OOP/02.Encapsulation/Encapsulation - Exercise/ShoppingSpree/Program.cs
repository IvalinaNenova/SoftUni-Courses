using System;
using System.Collections.Generic;

namespace ShoppingSpree
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Person> peopleList = new List<Person>();

            string[] peopleInput = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);

            try
            {
                foreach (var person in peopleInput)
                {
                    string[] personData = person.Split('=', StringSplitOptions.RemoveEmptyEntries);

                    Person newPerson = new Person(personData[0], decimal.Parse(personData[1]));

                    peopleList.Add(newPerson);
                }

                List<Product> products = new List<Product>();

                string[] productInput = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);

                foreach (var product in productInput)
                {
                    string[] productData = product.Split('=', StringSplitOptions.RemoveEmptyEntries);

                    Product newProduct = new Product(productData[0], decimal.Parse(productData[1]));

                    products.Add(newProduct);
                }

                string input = Console.ReadLine();

                while (input != "END")
                {
                    string[] shoppingList = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                    Person shopper = peopleList.Find(p => p.Name == shoppingList[0]);
                    Product productToBuy = products.Find(p => p.Name == shoppingList[1]);

                    shopper.AddProductsToBag(productToBuy);

                    input = Console.ReadLine();
                }

                foreach (var person in peopleList)
                {
                    Console.WriteLine(person);
                }
            }
            catch (ArgumentException exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
    }
}
