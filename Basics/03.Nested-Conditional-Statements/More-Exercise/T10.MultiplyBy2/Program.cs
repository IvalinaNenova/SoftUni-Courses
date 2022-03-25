using System;

namespace T10.MultiplyBy2
{
    class Program
    {
        static void Main(string[] args)
        {
            

            for (int i = int.MaxValue ; i > 0; i--)
            {
                double num = double.Parse(Console.ReadLine());
                
                if (num < 0)
                {
                    Console.WriteLine("Negative number!");
                    break;
                    
                }
            Console.WriteLine($"Result: {num * 2:f2}");
            }

        }
    }
}
