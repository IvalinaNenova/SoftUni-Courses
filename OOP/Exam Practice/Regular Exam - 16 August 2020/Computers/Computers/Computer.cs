namespace Computers
{
    public class Computer
    {
        public Computer(string manufacturer, string model, decimal price)
        {
            this.Manufacturer = manufacturer;
            this.Model = model;
            this.Price = price;
        }

        public string Manufacturer { get; set; }

        public string Model { get; set; }

        public decimal Price { get; set; }
    }
}