namespace Zoo
{
    public class Animal
    {
        private string species;
        private string diet;
        private double weight;
        private double length;

        public Animal(string species, string diet, double weight, double length)
        {
            this.Species = species;
            this.Diet = diet;
            this.Weight = weight;
            this.Length = length;
        }

        public string Species
        {
            get => this.species;
            private set
            {
                this.species = value;
            }
        }

        public string Diet
        {
            get => this.diet;
            private set
            {
                this.diet = value;
            }

        }

        public double Weight
        {
            get => this.weight;
            private set
            {
                this.weight = value;
            }
        }

        public double Length
        {
            get => this.length;
            private set
            {
                this.length = value;
            }
        }

        public override string ToString() => $"The {this.Species} is a {this.Diet} and weighs {this.Weight} kg.";
    }
}
