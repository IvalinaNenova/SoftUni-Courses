using System;

namespace T03._Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfPeopleInGroup = int.Parse(Console.ReadLine());

            string groupType = Console.ReadLine();
            string dayOfWeek = Console.ReadLine();

            double pricePerPerson = 0;

            switch (groupType)
            {
                case "Students":

                    switch (dayOfWeek)
                    {
                        case "Friday":
                            pricePerPerson = 8.45;
                            break;
                        case "Saturday":
                            pricePerPerson = 9.80;
                            break;
                        case "Sunday":
                            pricePerPerson = 10.46;
                            break;
                    }
                    break;

                case "Business":

                    switch (dayOfWeek)
                    {
                        case "Friday":
                            pricePerPerson = 10.90;
                            break;
                        case "Saturday":
                            pricePerPerson = 15.60;
                            break;
                        case "Sunday":
                            pricePerPerson = 16;
                            break;
                    }
                    break;

                case "Regular":

                    switch (dayOfWeek)
                    {
                        case "Friday":
                            pricePerPerson = 15;
                            break;
                        case "Saturday":
                            pricePerPerson = 20;
                            break;
                        case "Sunday":
                            pricePerPerson = 22.50;
                            break;
                    }
                    break;
            }

            double totalPrice = pricePerPerson * numberOfPeopleInGroup;

            if (groupType == "Students" && numberOfPeopleInGroup >= 30)
            {
                totalPrice *= 0.85;
            }
            else if (groupType == "Business" && numberOfPeopleInGroup >= 100)
            {
                totalPrice -= 10 * pricePerPerson;
            }
            else if (groupType == "Regular" && numberOfPeopleInGroup >= 10 && numberOfPeopleInGroup <= 20)
            {
                totalPrice *= 0.95;
            }

            Console.WriteLine($"Total price: {totalPrice:f2}");
        }
    }
}
