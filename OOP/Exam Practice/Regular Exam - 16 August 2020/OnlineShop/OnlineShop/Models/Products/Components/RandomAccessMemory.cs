namespace OnlineShop.Models.Products.Components
{
    public class RandomAccessMemory : Component
    {
        private const double Multiplier = 1.20;

        public RandomAccessMemory(int id, string manufacturer, string model, decimal price, double overallPerformance, int generation)
            : base(id, manufacturer, model, price, overallPerformance * Multiplier, generation)
        {
        }
    }
}
