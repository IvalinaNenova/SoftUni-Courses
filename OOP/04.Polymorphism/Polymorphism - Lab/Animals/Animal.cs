namespace Animals
{
    public class Animal
    {
        private string name;
        private string favouriteFood;

        public Animal(string name, string favouriteFood)
        {
            Name = name;
            FavouriteFood = favouriteFood;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string FavouriteFood
        {
            get { return favouriteFood; }
            set { favouriteFood = value; }
        }

        public virtual string ExplainSelf()
        {
            return $"I am {Name} and my favourite food is {FavouriteFood}";
        }
    }
}
