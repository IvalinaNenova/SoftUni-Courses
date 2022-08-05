﻿namespace TheRace
{
    public class UnitCar
    {
        public UnitCar(string model, int horsePower, double cubicCentimeters)
        {
            this.Model = model;
            this.HorsePower = horsePower;
            this.CubicCentimeters = cubicCentimeters;
        }

        public string Model { get; }

        public int HorsePower { get; }

        public double CubicCentimeters { get; }
    }
}