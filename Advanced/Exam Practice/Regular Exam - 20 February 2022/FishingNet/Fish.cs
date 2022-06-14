namespace FishingNet
{
    public class Fish
    {
        //•	FishType: string
        //•	Length: double
        //•	Weight: double

        private string fishType;

        private double length;

        private double weight;

        public Fish(string fishType, double length, double weight)
        {
            this.fishType = fishType;
            this.length = length;
            this.weight = weight;
        }

        public string FishType
        {
            get=> fishType;
            set
            {
                fishType = value;
            }
        }

        public double Length
        {
            get=> length;
            set=> length = value;

        }
        public double Weight
        {
            get => weight;
            set => weight = value;

        }

        public override string ToString()
        {
            return $"There is a {fishType}, {length} cm. long, and {weight} gr. in weight.";
        }
        //    The class constructor should receive fish type, length, and weight.
        //    The class should also have a method:
        //•	Override the ToString() method in the format: "There is a {fishType}, {length} cm. long, and {weight} gr. in weight."

    }
}
