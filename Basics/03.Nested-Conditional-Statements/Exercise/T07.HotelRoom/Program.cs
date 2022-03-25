using System;

namespace T07.HotelRoom
{
    class Program
    {
        static void Main(string[] args)
        {
            string month = Console.ReadLine();
            int numberOfNights = int.Parse(Console.ReadLine());
            double finalPriceForApartment = 0;
            double finalPriceForStudio = 0;

            if (month == "May" || month == "October")
            {
                finalPriceForStudio = 50 * numberOfNights;
                finalPriceForApartment = 65 * numberOfNights;

                if (numberOfNights>14)
                {
                    
                        finalPriceForStudio *= 0.7;
                        finalPriceForApartment *= 0.90;

                }
                else if (numberOfNights >7)
                {
                    finalPriceForStudio *= 0.95;
                }
            }
            else if (month == "June" || month == "September")
            {
                finalPriceForStudio = 75.20 * numberOfNights;
                finalPriceForApartment = 68.70 * numberOfNights;

                if (numberOfNights>14)
                {
                    
                        finalPriceForStudio *= 0.8;
                        finalPriceForApartment *= 0.90;
                        

                }
            }
            else if (month == "July" || month == "August")
            {
                finalPriceForStudio = 76 * numberOfNights;
                finalPriceForApartment = 77 * numberOfNights;
                if (numberOfNights >14)
                {
                    finalPriceForApartment *= 0.9;
                }
            }

            Console.WriteLine($"Apartment: {finalPriceForApartment:f2} lv.");
            Console.WriteLine($"Studio: {finalPriceForStudio:f2} lv.");


        }
    }
}
