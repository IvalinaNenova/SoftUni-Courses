using System;
using System.Text;

namespace T05._Login
{
    class Program
    {
        static void Main(string[] args)
        {
            string username = Console.ReadLine();

            string correctPassword = String.Empty;


            for (int i = username.Length - 1; i >= 0; i--)
            {
                correctPassword += username[i];
            }

            string passwordAttempt = String.Empty;
            int incorrectCounter = 0;

            while ((passwordAttempt = Console.ReadLine()) != correctPassword)
            {
                incorrectCounter++;

                if (incorrectCounter == 4)
                {
                    Console.WriteLine($"User {username} blocked!");
                    break;
                }

                Console.WriteLine("Incorrect password. Try again.");
            }

            if (passwordAttempt == correctPassword)
            {
                Console.WriteLine($"User {username} logged in.");
            }
        }


    }
}
