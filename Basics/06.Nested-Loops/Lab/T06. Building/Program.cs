using System;

namespace T06._Building
{
    class Program
    {
        static void Main(string[] args)
        {

            int numOfFloors = int.Parse(Console.ReadLine());
            int numOfRooms = int.Parse(Console.ReadLine());


            for (int floor = numOfFloors; floor >=1; floor--)
            {
                for (int room = 0; room <numOfRooms; room++)
                {
                    
                    if (floor == numOfFloors)
                    {
                        Console.Write($"L{floor}{room} ");
                        continue;
                    }
                    if (floor%2==0)
                    {
                        Console.Write($"O{floor}{room} ");
                    }
                    else
                    {
                        Console.Write($"A{floor}{room} ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
