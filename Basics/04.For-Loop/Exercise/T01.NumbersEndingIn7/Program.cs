using System;

namespace T01.NumbersEndingIn7
{
    class Program
    {
        static void Main(string[] args)
        {
            
            for (int num = 7; num <= 997; num++)
            {
                if (num%10==7)
                {
                    Console.WriteLine(num);
                }
            }
        }
    }
}
