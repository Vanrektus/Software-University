using System.Text;

namespace CarSalesman
{
    class Car
    {
        //---------------------------Properties---------------------------
        public string Model { get; private set; }
        public Engine Engine { get; private set; }
        public string Weight { get; private set; }
        public string Color { get; private set; }

        //---------------------------Constructors---------------------------
        public Car(string model, Engine engine, string weight, string color)
        {
            this.Model = model;
            this.Engine = engine;
            this.Weight = weight;
            this.Color = color;
        }

        //---------------------------Methods---------------------------
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.Model}:");
            sb.AppendLine($"  {this.Engine.Model}:");
            sb.AppendLine($"    Power: {Engine.Power}");
            sb.AppendLine($"    Displacement: {Engine.Displacement}");
            sb.AppendLine($"    Efficiency: {Engine.Efficiency}");
            sb.AppendLine($"  Weight: {this.Weight}");
            sb.AppendLine($"  Color: {this.Color}");
            return sb.ToString();
        }
    }
}
