namespace OnlineShop.Models.Products.Computers
{
    public class Laptop : Computer
    {
        public Laptop(int id, string manufacturer, string model, decimal price)
            : base(id, manufacturer, model, price, 10)
        {
        }
    }
}
