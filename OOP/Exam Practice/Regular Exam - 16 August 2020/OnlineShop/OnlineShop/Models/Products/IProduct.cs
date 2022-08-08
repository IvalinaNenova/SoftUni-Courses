namespace OnlineShop.Models.Products
{
    public interface IProduct
    {
        int Id { get; }

        string Manufacturer { get; }

        string Model { get; }

        decimal Price { get; }

        double OverallPerformance { get; }

    }
}
