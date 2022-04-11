
using System;

namespace S04._Cinema_Voucher
{
    class Program
    {
        static void Main(string[] args)
        {
            int voucher = int.Parse(Console.ReadLine());
            string item = Console.ReadLine();
            int movieTickets = 0;
            int other = 0;
            int sum = 0;
            while (item != "End")
            {
                int itemLenght = item.Length;
                char one = item[0];
                char two = item[1];
                int num1 = Convert.ToInt32(one);
                int num2 = Convert.ToInt32(two);
               
                if (itemLenght > 8)
                {
                    sum = num1 + num2;
                    if (sum <= voucher)
                    {
                        movieTickets++;
                    }
                }
                else
                {
                    sum = num1;
                    if (sum <= voucher)
                    {
                        other++;
                    }
                }
                voucher -= sum;
                if (voucher < 0)
                {
                    break;
                }

                item = Console.ReadLine();
            }
            Console.WriteLine(movieTickets);
            Console.WriteLine(other);
        }
    }
}
