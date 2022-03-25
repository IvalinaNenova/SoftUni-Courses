using System;

namespace T05.Salary
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfTabs = int.Parse(Console.ReadLine());
            int salary = int.Parse(Console.ReadLine());



            for (int i = 0; i <= numberOfTabs; i++)
            {
                string website = Console.ReadLine();
                if (website == "Facebook")
                {
                    salary -= 150;
                }
                else if (website == "Instagram")
                {
                    salary -= 100;
                }
                else if (website == "Reddit")
                {
                    salary -= 50;
                }
                else
                {
                    salary -= 0;
                }

                if (salary == 0)
                {
                    Console.WriteLine("You have lost your salary.");
                    break;
                }



            }
            if (salary > 0)
            {
                Console.WriteLine(salary);
            }

        }
    }
}
