using System;
using System.Collections.Generic;

namespace T05._SoftUni_Parking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, string> parkingLot = new Dictionary<string, string>();

            for (int i = 0; i < n; i++)
            {
                string[] userData = Console.ReadLine().Split(' ');
                string command = userData[0];
                string username = userData[1];

                if (command == "register")
                {
                    string licensePlate = userData[2];

                    if (!parkingLot.ContainsKey(username))
                    {
                        parkingLot.Add(username, licensePlate);
                        Console.WriteLine($"{username} registered {licensePlate} successfully");
                    }
                    else
                    {
                        Console.WriteLine($"ERROR: already registered with plate number {licensePlate}");
                    }
                }
                else if (command == "unregister")
                {
                    if (parkingLot.ContainsKey(username))
                    {
                        parkingLot.Remove(username);
                        Console.WriteLine($"{username} unregistered successfully");
                    }
                    else
                    {
                        Console.WriteLine($"ERROR: user {username} not found");
                    }
                }
            }

            foreach (var parkingUser in parkingLot)
            {
                Console.WriteLine($"{parkingUser.Key} => {parkingUser.Value}");
            }
        }
    }
}
