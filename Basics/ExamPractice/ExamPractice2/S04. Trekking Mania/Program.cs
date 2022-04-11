using System;

namespace S04._Trekking_Mania
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfGroups = int.Parse(Console.ReadLine());
            int totalPeople = 0;
            int Musala = 0;
            int MontBlanc = 0;
            int Kilimanjaro = 0;
            int K2 = 0;
            int Everest = 0;
            for (int i = 0; i < numberOfGroups; i++)
            {
                int peopleInGroup = int.Parse(Console.ReadLine());
                totalPeople += peopleInGroup;

                if (peopleInGroup <= 5)
                {
                    Musala += peopleInGroup;
                }
                else if (peopleInGroup <= 12)
                {
                    MontBlanc += peopleInGroup;
                }
                else if (peopleInGroup <= 25)
                {
                    Kilimanjaro += peopleInGroup;
                }
                else if (peopleInGroup <= 40)
                {
                    K2 += peopleInGroup;
                }
                else if (peopleInGroup >= 41)
                {
                    Everest += peopleInGroup;
                }
            }
            double p1 = (double)Musala / totalPeople * 100;
            double p2 = (double)MontBlanc / totalPeople * 100;
            double p3 = (double)Kilimanjaro / totalPeople * 100;
            double p4 = (double)K2 / totalPeople * 100;
            double p5 = (double)Everest / totalPeople * 100;

            Console.WriteLine($"{p1:f2}%");
            Console.WriteLine($"{p2:f2}%");
            Console.WriteLine($"{p3:f2}%");
            Console.WriteLine($"{p4:f2}%");
            Console.WriteLine($"{p5:f2}%");
        }
    }
}
