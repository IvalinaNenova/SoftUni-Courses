using System;

namespace T06._High_Jump
{
    class Program
    {
        static void Main(string[] args)
        {
            int target = int.Parse(Console.ReadLine());
            int startheight = target - 30;
            int tries = 0;
           
            for (int i = startheight; i <= target; i += 5)
            {
                int fail = 0;
                for (int j = 0; j < 3; j++)
                {
                    int attempt = int.Parse(Console.ReadLine());
                    tries++;
                    if (attempt > i)
                    {
                        if (attempt > target)
                        {
                            Console.WriteLine($"Tihomir succeeded, he jumped over {target}cm after {tries} jumps.");
                            return;
                        }
                        break;
                    }
                    else
                    {
                        fail++;
                        if (fail == 3)
                        {
                            Console.WriteLine($"Tihomir failed at {i}cm after {tries} jumps.");
                           return;
                        }
                    }

                }
            }
        }
    }
}
