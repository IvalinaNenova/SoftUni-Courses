using System;

namespace S04._Renovation
{
    class Program
    {
        static void Main(string[] args)
        {
           double height = int.Parse(Console.ReadLine());
            int width = int.Parse(Console.ReadLine());
            int percentOfWindows = int.Parse(Console.ReadLine());
            string command = Console.ReadLine();
            
            double areaToPaint = Math.Round (4*(height * width - height * width * percentOfWindows / 100));
            double areaLeft = areaToPaint;

            while (command!= "Tired!")
            {
                int littres = int.Parse(command);
                areaLeft -= littres;

                if (areaLeft<0)
                {
                    Console.WriteLine($"All walls are painted and you have {Math.Abs(areaLeft)} l paint left!");
                    break;
                }
                else if (areaLeft==0)
                {
                    Console.WriteLine("All walls are painted! Great job, Pesho!");
                }
                command = Console.ReadLine();
            }

            if (command=="Tired!")
            {
                Console.WriteLine($"{areaLeft} quadratic m left.");
            }
        }
    }
}
