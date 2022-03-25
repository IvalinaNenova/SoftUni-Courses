using System;

namespace T07.TrekkingMania
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfGroups = int.Parse(Console.ReadLine());
            int Musala = 0;
            int montBlanc = 0;
            int Kilimanjaro = 0;
            int k2 = 0;
            int everest = 0;
            double totalPeople = 0;

            for (int i = 0; i < numberOfGroups; i++)
            {
                int peopleInGroup = int.Parse(Console.ReadLine());
                
                if (peopleInGroup <=5)
                {
                    Musala += peopleInGroup;
                }
                else if (peopleInGroup >=6 && peopleInGroup <=12)
                {
                    montBlanc  += peopleInGroup;
                }
                else if (peopleInGroup >=13 && peopleInGroup <= 25)
                {
                    Kilimanjaro  += peopleInGroup;
                }
                else if (peopleInGroup >= 26 && peopleInGroup <= 40)
                {
                    k2 += peopleInGroup;
                }
                else if (peopleInGroup >40)
                {
                    everest += peopleInGroup;
                }
                totalPeople += peopleInGroup;
            }
            
                double musalaPercent = Musala / totalPeople * 100;
                double montBlancPercent = montBlanc / totalPeople * 100;
                double KilimanjaroPercent = Kilimanjaro / totalPeople * 100;
                double k2Percent = k2 / totalPeople * 100;
                double everestPercent = everest / totalPeople * 100;
            
            Console.WriteLine($"{musalaPercent:f2}%");
            Console.WriteLine($"{montBlancPercent:f2}%");
            Console.WriteLine($"{KilimanjaroPercent:f2}%");
            Console.WriteLine($"{k2Percent:f2}%");
            Console.WriteLine($"{everestPercent:f2}%");
        }
    }
}
