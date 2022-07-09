namespace Shapes
{
    public class Rectangle : Shape
    {
        private double height;
        private double width;

        public Rectangle(double height, double width)
        {
            Height = height;
            Width = width;
        }

        public double Width
        {
            get => width;
            private set => width = value;
        }

        public double Height
        {
            get => height;
            private set => height = value;
        }

        public override double CalculatePerimeter() //(h + w)*2
        {
            return 2 * Height + 2 * Width;
        }

        public override double CalculateArea() // height * width
        {
            return Height * Width;
        }

        public sealed override string Draw()
        {
            return base.Draw() + $"{this.GetType().Name}";
        }
    }
}
