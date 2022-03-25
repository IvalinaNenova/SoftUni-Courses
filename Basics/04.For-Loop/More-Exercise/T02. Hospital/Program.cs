using System;

namespace T02._Hospital
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            int treatedPetients = 0;
            int untreatedptients = 0;
            int doctors = 7;



            for (int i = 1; i <= days; i++)
            {
                int numberOfPatients = int.Parse(Console.ReadLine());
                if (i % 3 == 0 && untreatedptients > treatedPetients)
                {

                    doctors++;

                }


                if (numberOfPatients <= doctors)
                {
                    treatedPetients += numberOfPatients;
                }
                else
                {
                    treatedPetients += doctors;
                    untreatedptients += numberOfPatients - doctors;
                }

            }
            Console.WriteLine($"Treated patients: {treatedPetients}.");
            Console.WriteLine($"Untreated patients: {untreatedptients}.");
        }
    }
}
