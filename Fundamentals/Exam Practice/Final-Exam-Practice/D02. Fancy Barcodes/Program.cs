using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace D02._Fancy_Barcodes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfBarcodes = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfBarcodes; i++)
            {
                Match match = Regex.Match(Console.ReadLine(), @"@[#]+(?<barcode>[A-Z][A-Za-z0-9]{4,}[A-Z])@[#]+");
                string productGroup = "00";
                string tempGroup = string.Empty;

                if (match.Success)
                {
                    string barcode = match.Groups["barcode"].Value;

                    foreach (var symbol in barcode.Where(symbol => char.IsDigit(symbol)))
                    {
                        tempGroup += symbol;
                        productGroup = tempGroup;
                    }

                    Console.WriteLine($"Product group: {productGroup}");
                }
                else
                {
                    Console.WriteLine("Invalid barcode");
                }
            }
        }
    }
}
