using System;

namespace T05.Firm
{
    class Program
    {
        static void Main(string[] args)
        {
            int hoursNeededForProject = int.Parse(Console.ReadLine());
            int days = int.Parse(Console.ReadLine());
            int workers = int.Parse(Console.ReadLine());
            double totalHours = Math.Floor((days - (days * 0.1)) * 8 + workers * (2 * days));
            if (totalHours >= hoursNeededForProject)
            {
                Console.WriteLine($"Yes!{totalHours - hoursNeededForProject} hours left.");
            }
            else
            {
                Console.WriteLine($"Not enough time!{hoursNeededForProject - totalHours} hours needed.");
            }
        }
    }
}
