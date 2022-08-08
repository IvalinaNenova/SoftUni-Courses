namespace OnlineShop.Models.Products.Computers
{
    public class DesktopComputer : Computer
    {
        public DesktopComputer(int id, string manufacturer, string model, decimal price
        )
            : base(id, manufacturer, model, price, 15)
        {
        }
    }
}
