using System.Text;

namespace Shapes
{
    public class Rectangle : Shape
    {
        private int height;
        private int width;

        public Rectangle(int width, int height)
        {
            Height = height;
            Width = width;
        }

        public int Width
        {
            get => width;
            private set => width = value;
        }

        public int Height
        {
            get => height;
            private set => height = value;
        }

        public override double CalculatePerimeter() //(h + w)*2
        {
            return 2 * height + 2 * width;
        }

        public override double CalculateArea() // height * width
        {
            return height * width;
        }

        public override string Draw()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(new string('*', width));

            for (int i = 1; i < height - 1; i++)
            {
                sb.AppendLine('*' + new string(' ', width - 2) + '*');
            }

            sb.AppendLine(new string('*', width));

            return sb.ToString().TrimEnd();
        }
    }
}
