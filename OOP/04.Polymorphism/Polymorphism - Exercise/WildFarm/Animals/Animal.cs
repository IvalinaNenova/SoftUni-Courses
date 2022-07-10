namespace WildFarm.Animals
{
    using WildFarm.Food;
    public abstract class Animal
    {
        public Animal(string name, double weight)
        {
            Name = name;
            Weight = weight;
        }

        public abstract double WeightGainPerUnitOfFood { get; }
        public string Name { get; protected set; }
        public double Weight { get; protected set; }
        public int FoodEaten { get; protected set; }

        public virtual void Feed(Food food)
        {
            Weight += WeightGainPerUnitOfFood * food.Quantity;
            FoodEaten+= food.Quantity;
        }
        public abstract string ProduceSound();
    }
}
