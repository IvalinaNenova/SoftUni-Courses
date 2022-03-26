using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Threading.Tasks;

namespace Т06._Store_Boxes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

           List<Box> boxes = new List<Box>();

            while (input != "end")
            {
                string[] data = input.Split();

                string serialNumber = data[0];
                string itemName = data[1];
                int itemQuantity = int.Parse(data[2]);
                decimal itemPrice = decimal.Parse(data[3]);

                Item item = new Item(itemName, itemPrice);

                Box box = new Box();

                box.SerialNumber = serialNumber;
                box.Item = new Item(itemName, itemPrice);
                box.Quantity = itemQuantity;
                box.PriceBox = itemQuantity * itemPrice;

                boxes.Add(box);
                
                input = Console.ReadLine();
            }


            List<Box> sortedBoxes = boxes.OrderByDescending(b => b.PriceBox).ToList();

            foreach (Box box in sortedBoxes)
            {
                Console.WriteLine(box.SerialNumber);
                Console.WriteLine($"-- {box.Item.Name} - ${box.Item.Price:f2}: {box.Quantity}");
                Console.WriteLine($"-- ${box.PriceBox:f2}");
            }
        }
    }

    class Item
    {
        public Item()
        {

        }

        public Item(string name, decimal price)
        {
            this.Name = name;
            this.Price = price;
        }
        public string Name { get; set; }

        public decimal Price { get; set; }
    }

    class Box
    {
        public Box()
        {
            Item = new Item();
        }

        public string SerialNumber { get; set; }

        public Item Item { get; set; }

        public int Quantity { get; set; }

        public decimal PriceBox { get; set; }
    }
}
