using System;
using System.Collections.Generic;

namespace Exam_Problem_3
{
    class Something
    {
        public Something()
        {

        }

        public TYPE Type { get; set; }
        public TYPE Type1 { get; set; }
        public TYPE Type2 { get; set; }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Something> myDictionary = new Dictionary<string, Something>();

            string input = Console.ReadLine();

            while (input != "")
            {
                string[] commands = input.Split("");
                string action = commands[0];

                if (action == "")
                {

                }
                else if (action == "")
                {

                }
                else if (action == "")
                {

                }

                input = Console.ReadLine();
            }
        }
    }
}
