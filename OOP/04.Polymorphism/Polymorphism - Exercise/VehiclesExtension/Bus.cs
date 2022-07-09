using System;
using System.Collections.Generic;
using System.Text;

namespace VehiclesExtension
{
    public class Bus : Vehicle
    {
        private const double ConsumptionIncrease = 1.4;

        private AirConditionerMode airConditionerMode;
        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity) 
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
        }

        protected override double AdditionalConsumption =>
            airConditionerMode == AirConditionerMode.On 
                ? ConsumptionIncrease 
                : 0;

        public void SwitchACOn()
        {
            airConditionerMode = AirConditionerMode.On;
        }

        public void SwitchACOff()
        {
            airConditionerMode = AirConditionerMode.Off;
        }
    }
}
