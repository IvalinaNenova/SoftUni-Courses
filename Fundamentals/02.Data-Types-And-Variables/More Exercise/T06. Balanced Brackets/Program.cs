using System;

namespace Balanced_Brackets
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfLines = int.Parse(Console.ReadLine());

            bool isOpened = false;
            bool isBalanced = true;

            for (int n = 0; n < numberOfLines; n++)
            {
                string input = Console.ReadLine();

                if (input == "(")
                {
                    if (!isOpened)
                    {
                        isOpened = true;
                    }
                    else
                    {
                        isBalanced = false;
                    }
                }

                if (input == ")")
                {
                    if (isOpened)
                    {
                        isOpened = false;
                    }
                    else
                    {
                        isBalanced = false;
                    }
                }
            }

            if (isBalanced && !isOpened)
            {
                Console.WriteLine("BALANCED");
            }
            else
            {
                Console.WriteLine("UNBALANCED");
            }
        }
    }
}