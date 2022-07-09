using System;

namespace Shapes
{
    public class Circle : Shape
    {
        private double radius;

        public Circle(double radius)
        {
            Radius = radius;
        }

        public double Radius
        {
            get => radius;
            private set => radius = value;
        }

        public override double CalculatePerimeter() // r *2 * pi
        {
           return 2 * Math.PI * Radius;
        }

        public override double CalculateArea()// pi * r^2
        {
            return Math.PI * (Radius * Radius);
        }

        public sealed override string Draw()
        {
            return base.Draw() + $"{this.GetType().Name}";
        }
    }
}
