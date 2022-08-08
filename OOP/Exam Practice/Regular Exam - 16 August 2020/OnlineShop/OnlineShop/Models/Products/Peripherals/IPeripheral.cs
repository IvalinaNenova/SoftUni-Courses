namespace OnlineShop.Models.Products.Peripherals
{
    public interface IPeripheral : IProduct
    {
        string ConnectionType { get; }
    }
}
