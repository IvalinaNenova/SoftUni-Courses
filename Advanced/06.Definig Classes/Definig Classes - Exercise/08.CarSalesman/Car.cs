using System.Text;

namespace DefiningClasses
{
    public class Car
    {
        public string Model { get; set; }

        public Engine Engine { get; set; }

        public int Weight { get; set; }
        public string Color { get; set; }

        public Car(string model, Engine engine)
        {
            Model = model;
            Engine = engine;
        }

        public override string ToString()
        {
           StringBuilder sb = new StringBuilder();
           
            sb.AppendLine($"{Model}:");
            sb.AppendLine($"  {Engine.Model}:");
            sb.AppendLine($"    Power: {Engine.Power}");
            sb.AppendLine(Engine.Displacement == 0 ? "    Displacement: n/a" : $"    Displacement: {Engine.Displacement}");
            sb.AppendLine(Engine.Efficiency == null ? "    Efficiency: n/a" : $"    Efficiency: {Engine.Efficiency}");
            sb.AppendLine(Weight == 0 ? "  Weight: n/a" : $"  Weight: {Weight}");
            sb.Append(Color == null ? "  Color: n/a" : $"  Color: {Color}");
            return sb.ToString();
        }
    }
}
