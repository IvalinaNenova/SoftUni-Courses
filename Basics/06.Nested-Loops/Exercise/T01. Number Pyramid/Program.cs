using System;

namespace T01._Number_Pyramid
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            
            int currNum = 1;

            bool isEqual = false;

            for (int rows = 1; rows <=n; rows++)
            {
                for (int columns = 1; columns <= rows; columns++)
                {

                    if (currNum >n)
                    {
                        isEqual = true;
                        break;
                    }
                    Console.Write($"{currNum} ");
                    currNum++;
                }
                if (isEqual)
                {
                    break;
                }
                Console.WriteLine();
            
            }

        }
    }
}
