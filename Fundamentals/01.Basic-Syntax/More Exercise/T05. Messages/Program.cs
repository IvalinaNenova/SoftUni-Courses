using System;

namespace T05._Messages
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int messageLenght = int.Parse(Console.ReadLine());


            string message = string.Empty;

            for (int i = 0; i < messageLenght; i++)
            {
                string number = Console.ReadLine();
                int digit = int.Parse(number[0].ToString());
                int offset = (digit - 2) * 3;

                if (digit == 0)
                {
                    message += " ";
                    continue;
                }

                if (digit == 8 || digit == 9)
                {
                    offset++;
                }

                int digitLength = number.Length;
                int letterIndex = offset + digitLength - 1;
                message += (char)(letterIndex + 97);
            }

            Console.WriteLine(message);
        }
    }
}
