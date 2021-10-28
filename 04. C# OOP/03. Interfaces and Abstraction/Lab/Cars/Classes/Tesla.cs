using System.Text;

namespace Cars
{
    public class Tesla : Car, IElectricCar
    {
        //---------------------------Properties---------------------------
        public int Battery { get; private set; }

        //---------------------------Constructors---------------------------
        public Tesla(string model, string color, int battery)
            : base (model, color)
        {
            this.Battery = battery;
        }

        //---------------------------Methods---------------------------
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{this.Color} Tesla {this.Model} with {this.Battery} Batteries");
            sb.AppendLine(this.Start());
            sb.AppendLine(this.Stop());

            return sb.ToString().TrimEnd();
        }
    }
}
