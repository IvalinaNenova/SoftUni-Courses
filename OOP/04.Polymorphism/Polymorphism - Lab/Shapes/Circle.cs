using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    public class Circle : Shape
    {
        private int radius;

        public Circle(int radius)
        {
            Radius = radius;
        }

        public int Radius
        {
            get => radius;
            private set => radius = value;
        }

        public override double CalculatePerimeter() // r *2 * pi
        {
            return radius * 2 * Math.PI;
        }

        public override double CalculateArea()// pi * r^2
        {
            return Math.PI * (radius * radius);
        }

        public override string Draw()
        {
            StringBuilder sb = new StringBuilder();
            double rIn = radius - 0.4;
            double rOut = radius + 0.4;

            for (double i = radius; i >= -radius; i--)
            {
                for (double j = -radius; j < rOut; j += 0.5)
                {
                    double value = i * i + j * j;

                    if (value >= rIn * rIn && value <= rOut * rOut)
                    {
                        sb.Append('*');
                    }
                    else
                    {
                        sb.Append(' ');
                    }
                }
                sb.AppendLine();
            }

            return sb.ToString().TrimEnd();
        }
    }
}
