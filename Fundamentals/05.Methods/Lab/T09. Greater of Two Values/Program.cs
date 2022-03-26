using System;

namespace T09._Greater_of_Two_Values
{
    class Program
    {
        static void Main(string[] args)
        {
            string variableType = Console.ReadLine();
            string a = Console.ReadLine();
            string b = Console.ReadLine();

            if (variableType == "int")
            {
                Console.WriteLine(GetMax(int.Parse(a), int.Parse(b)));
            }
            else if (variableType == "char")
            {
                Console.WriteLine(GetMax(char.Parse(a), char.Parse(b)));
            }
            else if (variableType == "string")
            {
                Console.WriteLine(GetMax(a, b));
            }

        }

        static int GetMax(int a, int b)
        {
            if (a > b)
            {
                return a;
            }
            return b;
        }

        static char GetMax(char a, char b)
        {
            if (a > b)
            {
                return a;
            }
            return b;
        }

        static string GetMax(string a, string b)
        {
            if (a.CompareTo(b) > 0)
            {
                return a;
            }
            return b;
        }
    }
}
