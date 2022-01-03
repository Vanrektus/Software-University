using System.Text;

namespace Cars
{
    public class Seat : Car
    {
        //---------------------------Constructors---------------------------
        public Seat(string model, string color)
            : base(model, color)
        {

        }

        //---------------------------Methods---------------------------
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{this.Color} Seat {this.Model}");
            sb.AppendLine(this.Start());
            sb.AppendLine(this.Stop());

            return sb.ToString().TrimEnd();
        }
    }
}
