using System;

namespace T03._Sum_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            int sum = 0;

            //while (sum <num)
            //{
            //    int currentNum = int.Parse(Console.ReadLine());
            //    sum += currentNum;
            //}
            //Console.WriteLine(sum);

            //while (true)
            //{
            //    int currentNum = int.Parse(Console.ReadLine());
            //    sum += currentNum;

            //    if (sum>=num)
            //    {
            //        break;
            //    }
            //}
            //    Console.WriteLine(sum);

            while (true)
            {
                int currentNum = int.Parse(Console.ReadLine());
                sum += currentNum;
                if (sum<num)
                {
                    continue;
                }
                break;
            }
            Console.WriteLine(sum);

        }
    }
}
