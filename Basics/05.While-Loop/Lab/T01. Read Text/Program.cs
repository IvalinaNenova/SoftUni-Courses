using System;

namespace T01._Read_Text
{
    class Program
    {
        static void Main(string[] args)
        {
            //string text = Console.ReadLine();

            //while (text != "Stop")
            //{
            //    Console.WriteLine(text);
            //    text = Console.ReadLine();
            //}


            //while (true)
            //{
            //string text = Console.ReadLine();

            //    if (text == "Stop")
            //    {

            //        break;
            //    }
            //    Console.WriteLine(text);
            //}

            while (true)
            {
                string text = Console.ReadLine();
                if (text!= "Stop")
                {
                    Console.WriteLine(text);
                    continue;
                }
                break;
            }
        }
    }
}
