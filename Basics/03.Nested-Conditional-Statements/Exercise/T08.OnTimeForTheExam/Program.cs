using System;

namespace T08.OnTimeForTheExam
{
    class Program
    {
        static void Main(string[] args)
        {
            // От конзолата се четат 4 цели числа(по едно на ред), въведени от потребителя:
            //•	Първият ред съдържа час на изпита – цяло число от 0 до 23.
            //•	Вторият ред съдържа минута на изпита – цяло число от 0 до 59.
            //•	Третият ред съдържа час на пристигане – цяло число от 0 до 23.
            //•	Четвъртият ред съдържа минута на пристигане – цяло число от 0 до 59.

            int hourOfExam = int.Parse(Console.ReadLine());
            int minuteOfExam = int.Parse(Console.ReadLine());
            int hourOfArrival = int.Parse(Console.ReadLine());
            int minuteOfArrival = int.Parse(Console.ReadLine());

            int timeOfExam = hourOfExam * 60 + minuteOfExam;
            int timeOfArrival = hourOfArrival * 60 + minuteOfArrival;
            

            if (timeOfArrival > timeOfExam)
            {
                Console.WriteLine("Late");
            }
            else if (timeOfArrival <= timeOfExam && timeOfArrival >= timeOfExam - 30)
            {
                Console.WriteLine("On time");
            }
            else
            {
                Console.WriteLine("Early");
            }
            int difference = Math.Abs(timeOfArrival - timeOfExam);

            if (timeOfArrival < timeOfExam && timeOfArrival > timeOfExam - 60)
            {
                Console.WriteLine($"{difference} minutes before the start");
            }
            else if (timeOfArrival <= timeOfExam - 60)
            {
                int hours = difference / 60;
                int minutes = difference % 60;
                Console.WriteLine($"{hours}:{minutes:d2} hours before the start");
            }
            else if (timeOfArrival > timeOfExam && timeOfArrival < timeOfExam +60)
            {
                Console.WriteLine($"{difference} minutes after the start");
            }
            else if (timeOfArrival >= timeOfExam +60)
            {
                int hours = difference / 60;
                int minutes = difference % 60;
                Console.WriteLine($"{hours}:{minutes:d2} hours after the start");
            }


        }
    }
}
