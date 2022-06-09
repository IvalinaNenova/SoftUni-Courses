using System;

namespace _08.Threeuple
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            var tuple1 = new Threeuple<string, string, string>(input[0] + " " + input[1], input[2], input[3]);
            Console.WriteLine(tuple1.ToString());

            string[] input2 = Console.ReadLine().Split();
            bool isDrunk = input2[2] == "drunk" ? true : false;
            var tuple2 = new Threeuple<string, int, bool>(input2[0], int.Parse(input2[1]), isDrunk);
            Console.WriteLine(tuple2.ToString());

            string[] input3 = Console.ReadLine().Split();
            var tuple3 = new Threeuple<string,double, string>(input3[0], double.Parse(input3[1]),input3[2]);
            Console.WriteLine(tuple3.ToString());
        }
    }
}
