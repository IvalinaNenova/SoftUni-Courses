using System;

namespace T05._Best_Player
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int mostGoals = 0;
            string bestPlayer = "";

            while (name!="END")
            {
                int numberOfGoals = int.Parse(Console.ReadLine());
                if (numberOfGoals>mostGoals)
                {
                    mostGoals = numberOfGoals;
                    bestPlayer = name;
                }
                
                if (numberOfGoals>=10)
                {
                    break;
                }
                name = Console.ReadLine();

            }
            Console.WriteLine($"{bestPlayer} is the best player!");
            if (mostGoals>=3)
            {
                Console.WriteLine($"He has scored {mostGoals} goals and made a hat-trick !!!");
            }
            else
            {
                Console.WriteLine($"He has scored {mostGoals} goals.");
            }

        }
    }
}
