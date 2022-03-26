using System;

namespace T07._Concat_Names
{
    class Program
    {
        static void Main(string[] args)
        {
            string firstName = Console.ReadLine();
            string lastName = Console.ReadLine();
            string delimeter = Console.ReadLine();

            Console.WriteLine(firstName + delimeter + lastName);
        }
    }
}
