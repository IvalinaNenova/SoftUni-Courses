namespace FoodShortage
{
    public class Citizen : IIdentifiable, IBirthable, IBuyer
    {
        private const int DefaultFoodPortion = 10;

        private string name;
        private int age;
        private string id;
        private string birthday;
        private int food = 0;
        public Citizen(string name, int age, string id, string birthday)
        {
            Name = name;
            Age = age;
            Id = id;
            Birthday = birthday;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public int Age
        {
            get { return age; }
            set { age = value; }
        }
        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Birthday
        {
            get { return birthday; }
            set { birthday = value; }
        }

        public int Food => food;

        public void BuyFood()
        {
            this.food += DefaultFoodPortion;
        }
    }
}
