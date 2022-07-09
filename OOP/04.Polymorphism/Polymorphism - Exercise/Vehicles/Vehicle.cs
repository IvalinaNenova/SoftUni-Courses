namespace Vehicles
{
    public abstract class Vehicle
    {
        private double fuelQuantity;
        private double fuelConsumption;

        protected Vehicle(double fuelQuantity, double fuelConsumption)
        {
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
        }

        public double FuelQuantity
        {
            get => fuelQuantity;
            protected set => fuelQuantity = value;
        }

        public double FuelConsumption
        {
            get => fuelConsumption;
            private set => fuelConsumption = value;
        }

        protected abstract double AdditionalConsumption { get; }

        public virtual void Refuel(double fuel)
        {
            FuelQuantity += fuel;
        }

        public string Drive(double kilometers)
        {
            double fuelNeeded = (FuelConsumption + AdditionalConsumption) * kilometers;

            if (fuelNeeded <= FuelQuantity)
            {
                fuelQuantity -= fuelNeeded;
                return $"{this.GetType().Name} travelled {kilometers} km";
            }
            else
            {
                return $"{this.GetType().Name} needs refueling";
            }
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:f2}";
        }
    }
}
