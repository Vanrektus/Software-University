using System.Text;

namespace StreetRacing
{
    public class Car
    {
        //---------------------------Properties---------------------------
        public string Make { get; private set; }

        public string Model { get; private set; }

        public string LicensePlate { get; private set; }

        public int HorsePower { get; private set; }

        public double Weight { get; private set; }

        //---------------------------Constructors---------------------------
        public Car(string make, string model, string licensePlate, int horsePower, double weight)
        {
            Make = make;
            Model = model;
            LicensePlate = licensePlate;
            HorsePower = horsePower;
            Weight = weight;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Make: {Make}");
            sb.AppendLine($"Model: {Model}");
            sb.AppendLine($"License Plate: {LicensePlate}");
            sb.AppendLine($"Horse Power: {HorsePower}");
            sb.Append($"Weight: {Weight}");

            return sb.ToString();
        }
    }
}
