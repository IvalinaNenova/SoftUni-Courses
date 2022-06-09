using System;

namespace _07.Tuple
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            Tuple<string, string> tuple1 = new Tuple<string, string>(input[0] + " " + input[1], input[2]);
            Console.WriteLine(tuple1.ToString());

            string[] input2 = Console.ReadLine().Split();
            Tuple<string, int> tuple2 = new Tuple<string, int>(input2[0], int.Parse(input2[1]));
            Console.WriteLine(tuple2.ToString());

            string[] input3 = Console.ReadLine().Split();
            Tuple<int, double> tuple3 = new Tuple<int, double>(int.Parse(input3[0]), double.Parse(input3[1]));
            Console.WriteLine(tuple3.ToString());
        }
    }
}
