using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Т03._Take_Skip_Rope
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            List<char> characters = text.ToCharArray().ToList();

            List<char> numChars = characters.Where(char.IsDigit).ToList();
            List<int> numbers = numChars.Select(s => int.Parse(s.ToString())).ToList();

            characters.RemoveAll(x => numChars.Contains(x));

            List<int> takeList = new List<int>(characters.Count / 2);
            List<int> skipList = new List<int>(characters.Count / 2);

            for (int i = 0; i < numbers.Count; i++)
            {
                if (i % 2 == 0)
                {
                    takeList.Add(numbers[i]);
                }
                else
                {
                    skipList.Add(numbers[i]);
                }
            }

            StringBuilder message = new StringBuilder();

            for (int i = 0; i < takeList.Count; i++)
            {
                int take = takeList[i];
                int skip = skipList[i];

                if (take >=characters.Count-1)
                {
                    message.AppendJoin("", characters.Take(characters.Count));
                    break;
                }

                message.AppendJoin("", characters.Take(take));
                characters.RemoveRange(0, skip + take);
            }
            
            Console.WriteLine(message);
        }
    }
}
