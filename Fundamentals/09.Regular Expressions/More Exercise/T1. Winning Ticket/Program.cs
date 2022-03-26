using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace T1._Winning_Ticket
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] ticketsCollection = Console.ReadLine()
                .Split(new char[] {',', ' '}, StringSplitOptions.RemoveEmptyEntries);

            foreach (var ticket in ticketsCollection)
            {
                if (ticket.Length != 20)
                {
                    Console.WriteLine("invalid ticket");
                }
                else
                {
                    string jackpotPattern = @"(\@{6,10}|\${6,10}|\^{6,10}|\#{6,10})";
                    var firstHalf = Regex.Match(ticket.Substring(0, 10), jackpotPattern);
                    var secondHalf = Regex.Match(ticket.Substring(10, 10), jackpotPattern);


                    if (firstHalf.Success && secondHalf.Success)
                    {
                        int winLength = Math.Min(firstHalf.Value.Length, secondHalf.Value.Length);

                        var leftSide = firstHalf.Value.Substring(0, winLength);
                        var rightSide = secondHalf.Value.Substring(0, winLength);

                        if (leftSide.Equals(rightSide))
                        {
                            if (leftSide.Length == 10)
                            {
                                Console.WriteLine($"ticket \"{ticket}\" - {leftSide.Length}{leftSide[0]} Jackpot!");
                            }
                            else
                            {
                                Console.WriteLine($"ticket \"{ticket}\" - {leftSide.Length}{leftSide[0]}");
                            }
                        }
                        else
                        {
                            Console.WriteLine($"ticket \"{ticket}\" - no match");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"ticket \"{ticket}\" - no match");
                    }
                }
            }
        }
    }
}
