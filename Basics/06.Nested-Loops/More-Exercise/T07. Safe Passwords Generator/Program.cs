using System;

namespace T07._Safe_Passwords_Generator
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int A = 35;
            int B = 64;
            int maxPasswords = int.Parse(Console.ReadLine());
            bool isMax = false;
            int passwords = 0;


            for (int x = 1; x <= a; x++)
            {
                for (int y = 1; y <= b; y++)
                {
                    if (passwords == maxPasswords)
                    {
                        isMax = true;
                        break;
                    }
                    char symbolA = Convert.ToChar(A);
                    char symbolB = Convert.ToChar(B);
                    Console.Write($"{symbolA}{symbolB}{x}{y}{symbolB}{symbolA}|");
                    A++;
                    B++;
                    passwords++;
                    if (A > 55)
                    {
                        A = 35;
                    }
                    if (B > 96)
                    {
                        B = 64;
                    }
                }
                if (isMax)
                {
                    break;
                }
            }

        }
    }
}
