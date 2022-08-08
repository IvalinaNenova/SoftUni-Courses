namespace OnlineShop.Models.Products.Components
{
    public interface IComponent : IProduct
    {
        int Generation { get; }
    }
}
