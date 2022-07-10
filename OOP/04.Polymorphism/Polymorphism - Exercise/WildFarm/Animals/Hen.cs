namespace WildFarm.Animals
{
    public class Hen : Bird
    {
        public Hen(string name, double weight, double wingSize)
            : base(name, weight, wingSize)
        {
        }

        public override double WeightGainPerUnitOfFood => 0.35;

        public override string ProduceSound()
        {
            return "Cluck";
        }
    }
}
