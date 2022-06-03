using System;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string date1 = Console.ReadLine();
            string date2 = Console.ReadLine();
            DateModifier difference = new DateModifier();
            TimeSpan diff = difference.GetDifference(date1, date2);
            Console.WriteLine(diff.Days.ToString());
        }
    }
}
