namespace Vehicles
{
    public class Truck : Vehicle
    {
        private const double ConsumptionIncrease = 1.6;
        private const double PercentageOfFuelRefueled = 0.95;

        public Truck(double fuelQuantity, double fuelConsumption)
            : base(fuelQuantity, fuelConsumption)
        {
        }

        protected override double AdditionalConsumption => ConsumptionIncrease;

        public override void Refuel(double fuel)
        {
            fuel *= PercentageOfFuelRefueled;
            base.Refuel(fuel);
        }

    }
}
