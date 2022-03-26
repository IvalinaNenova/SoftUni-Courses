using System;
using System.Text;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input1 = Console.ReadLine();
            string input2 = Console.ReadLine();

            StringBuilder output = new StringBuilder(input1);


            for (int i = 0; i < input2.Length; i++)
            {
                if (input2[i] == input1[i])
                {
                    continue;
                }
                else
                {
                    output[i] = input2[i];
                }

                Console.WriteLine(output);
            }
        }
    }
}
