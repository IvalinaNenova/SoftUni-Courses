using System;

namespace WildFarm.Animals
{
    using WildFarm.Food;

    public class Owl : Bird
    {
        public Owl(string name, double weight, double wingSize)
            : base(name, weight, wingSize)
        {
        }


        public override double WeightGainPerUnitOfFood => 0.25;

        public override void Feed(Food food)
        {
            if (!(food is Meat))
            {
                throw new ArgumentException($"{this.GetType().Name} does not eat {food.GetType().Name}!");
            }

            base.Feed(food);
        }

        public override string ProduceSound()
        {
            return "Hoot Hoot";
        }
    }
}
