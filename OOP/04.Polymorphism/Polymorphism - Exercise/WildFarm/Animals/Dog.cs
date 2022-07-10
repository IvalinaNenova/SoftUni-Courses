using System;

namespace WildFarm.Animals
{
    using WildFarm.Food;

    public class Dog : Mammal
    {
        public Dog(string name, double weight, string livingRegion)
            : base(name, weight, livingRegion)
        {
        }
        public override double WeightGainPerUnitOfFood => 0.40;

        public override void Feed(Food food)
        {
            if (!(food is Meat))
            {
                throw new ArgumentException($"{GetType().Name} does not eat {food.GetType().Name}!");
            }
            
            base.Feed(food);
        }

        public override string ProduceSound()
        {
            return "Woof!";
        }
    }
}
