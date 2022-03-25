using System;

namespace T01._Old_Books
{
    class Program
    {
        static void Main(string[] args)
        {
            //string input = Console.ReadLine();
            //string checkedBook = "";
            //int numberOfBooks = 0;

            //while (checkedBook != input)
            //{
            //    checkedBook = Console.ReadLine();
            //    if (checkedBook == "No More Books")
            //    {
            //        Console.WriteLine("The book you search is not here!");
            //        Console.WriteLine($"You checked {numberOfBooks} books.");
            //        break;
            //    }
            //    numberOfBooks++;
            //    if (checkedBook == input)
            //    {
            //        Console.WriteLine($"You checked {numberOfBooks} books and found it.");
            //        break;

            //    }


            //}

            string input = Console.ReadLine();
            string checkedBook = "";
            int numberOfBooks = 0;

            while (checkedBook != input)
            {
                checkedBook = Console.ReadLine();
                if (checkedBook == "No More Books")
                {
                    Console.WriteLine("The book you search is not here!");
                    Console.WriteLine($"You checked {numberOfBooks} books.");
                    break;
                }
                if (checkedBook != input)
                {
                    numberOfBooks++;
                }

            }

            if (checkedBook == input)
            {
                Console.WriteLine($"You checked {numberOfBooks} books and found it.");
            }


        }
    }
}
