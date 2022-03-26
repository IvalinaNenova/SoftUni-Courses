using System;

namespace T07._Repeat_String
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            int count = int.Parse(Console.ReadLine());

            string result = RepeatedText(text, count);
            Console.WriteLine(result);
        }

        private static string RepeatedText(string text, int count)
        {
            string result = "";
            for (int i = 0; i < count; i++)
            {
                result += text;
            }
            return result;
        }
    }
}
