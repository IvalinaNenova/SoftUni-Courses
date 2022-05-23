using System;
using System.Collections.Generic;

namespace T08._SoftUni_Party
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> VIPList = new HashSet<string>();
            HashSet<string> regularList = new HashSet<string>();

            string guestNumber = Console.ReadLine();

            while (guestNumber != "PARTY")
            {
                if (char.IsDigit(guestNumber[0]))
                {
                    VIPList.Add(guestNumber);
                }
                else
                {
                    regularList.Add(guestNumber);
                }

                guestNumber = Console.ReadLine();
            }

            string arrivingGuestNumber = Console.ReadLine();

            while (arrivingGuestNumber != "END")
            {
                if (VIPList.Contains(arrivingGuestNumber))
                {
                    VIPList.Remove(arrivingGuestNumber);
                }

                if (regularList.Contains(arrivingGuestNumber))
                {
                    regularList.Remove(arrivingGuestNumber);
                }

                arrivingGuestNumber = Console.ReadLine();
            }

            int countOfNoShows = VIPList.Count + regularList.Count;

            Console.WriteLine(countOfNoShows);
            foreach (var number in VIPList)
            {
                Console.WriteLine(number);
            }
            foreach (var number in regularList)
            {
                Console.WriteLine(number);
            }
        }
    }
}
