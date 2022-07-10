namespace WildFarm.Factories
{
    using WildFarm.Food;

    static class FoodFactory
    {
        public static Food CreateFood(string type, int quantity)
        {
            switch (type)
            {
                case "Meat":
                    return new Meat(quantity);
                case "Vegetable":
                    return new Vegetable(quantity);
                case "Fruit":
                    return new Fruit(quantity);
                case "Seeds":
                    return new Seeds(quantity);
                default: return null;
            }
        }
    }
}
