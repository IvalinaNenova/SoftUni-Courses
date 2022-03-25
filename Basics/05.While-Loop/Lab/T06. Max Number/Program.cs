using System;

namespace T06._Max_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int maxNum = int.MinValue;

            while (input != "Stop")
            {
                int num = int.Parse(input);
                input = Console.ReadLine();

                if (num>maxNum )
                {
                    maxNum = num;
                }
            }
            Console.WriteLine(maxNum);
        }
    }
}
