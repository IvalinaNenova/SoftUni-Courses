using System;

namespace T02._Password
{
    class Program
    {
        static void Main(string[] args)
        {
            string username = Console.ReadLine();
            string password = Console.ReadLine();

            //string passInput = "";

            //while (passInput !=password )
            //{
            //    passInput = Console.ReadLine();


            //}
            //Console.WriteLine($"Welcome {username}!");

            //while (true)
            //{
            //    string passInput = Console.ReadLine();
            //    if (passInput == password)
            //    {
            //    break;
            //    }
            //}
            //        Console.WriteLine($"Welcome {username}!");

            while (true)
            {

                string passInput = Console.ReadLine();
                if (passInput !=password )
                {
                    continue;
                }
                Console.WriteLine($"Welcome {username}!");
                break;
            }

        }
    }
}
