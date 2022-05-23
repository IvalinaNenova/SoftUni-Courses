using System;
using System.Collections.Generic;
using System.Linq;

namespace T07._Parking_Lot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            HashSet<string> parkingLot = new HashSet<string>();

            while (input != "END")
            {
                string[] parkingData = input.Split(", ");
                string direction = parkingData[0];
                string licensePlate = parkingData[1];

                switch (direction)
                {
                    case "IN":
                        parkingLot.Add(licensePlate);
                        break;
                    case "OUT":
                        parkingLot.Remove(licensePlate);
                        break;
                }

                input = Console.ReadLine();
            }

            if (parkingLot.Any())
            {
                foreach (var car in parkingLot)
                {
                    Console.WriteLine(car);
                }
            }
            else
            {
                Console.WriteLine("Parking Lot is Empty");
            }
        }
    }
}
