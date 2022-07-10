using WildFarm.Animals;

namespace WildFarm.Factories
{
    public static class AnimalFactory
    {
        public static Animal CreateAnimal(params string[] data)
        {
            string type = data[0];
            string name = data[1];
            double weight = double.Parse(data[2]);

            switch (type)
            {
                case "Owl":
                    {
                        double wingSize = double.Parse(data[3]);
                        return new Owl(name, weight, wingSize);
                    }
                case "Hen":
                    {
                        double wingSize = double.Parse(data[3]);
                        return new Hen(name, weight, wingSize);
                    }
                case "Mouse":
                    {
                        string livingRegion = data[3];
                        return new Mouse(name, weight, livingRegion);
                    }
                case "Dog":
                    {
                        string livingRegion = data[3];
                        return new Dog(name, weight, livingRegion);
                    }
                case "Cat":
                    {
                        string livingRegion = data[3];
                        string breed = data[4];
                        return new Cat(name, weight, livingRegion, breed);
                    }
                case "Tiger":
                    {
                        string livingRegion = data[3];
                        string breed = data[4];
                        return new Tiger(name, weight, livingRegion, breed);
                    }
                default:
                    return null;
            }
        }
    }
}
