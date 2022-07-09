namespace VehiclesExtension
{
    public class Truck : Vehicle
    {
        private const double ConsumptionIncrease = 1.6;
        private const double PercentageOfFuelDecrease = 0.5;

        public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
        }

        protected override double AdditionalConsumption => ConsumptionIncrease;

        public override void Refuel(double fuel)
        {
            base.Refuel(fuel);
            FuelQuantity -= fuel * PercentageOfFuelDecrease;
        }
    }
}
