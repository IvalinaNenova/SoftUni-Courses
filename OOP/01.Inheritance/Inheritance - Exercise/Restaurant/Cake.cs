namespace Restaurant
{
    public class Cake : Dessert
    {
        private const decimal CakePrice = 5;
        private const double CakeGrams = 250;
        private const double CakeCalories = 1000;
        
        public Cake(string name)
            : base(name, CakePrice, CakeGrams, CakeCalories)
        {
        }
    }
}
