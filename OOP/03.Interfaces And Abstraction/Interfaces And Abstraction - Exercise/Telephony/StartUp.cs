using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;

namespace Telephony
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] phoneNumbers = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string[] sites = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            ICall phone;

            foreach (var phoneNumber in phoneNumbers)
            {
                if(!Regex.IsMatch(phoneNumber, @"^[0-9]+$"))
                {
                    Console.WriteLine("Invalid number!");
                    continue;
                }

                if (phoneNumber.Length == 7)
                {
                    phone = new StationaryPhone();
                }
                else
                {
                    phone = new Smartphone();
                }

                phone.Call(phoneNumber);
            }

            IBrowse smartPhone = new Smartphone();

            foreach (var site in sites)
            {
                //if (site.Any(char.IsDigit))
                //{
                //    Console.WriteLine("Invalid URL!"); 
                //    continue;
                //}

                if (!Regex.IsMatch(site, @"^[^\d+]+$"))
                {
                    Console.WriteLine("Invalid URL!");
                    continue;
                }

                smartPhone.Browse(site);
            }
        }
    }
}
