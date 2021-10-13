namespace SkiRental
{
    public class Ski
    {
        //---------------------------Properties---------------------------
        public string Manufacturer { get; set; }

        public string Model { get; set; }

        public int Year { get; set; }

        //---------------------------Constructors---------------------------
        public Ski(string manufacturer, string model, int year)
        {
            Manufacturer = manufacturer;
            Model = model;
            Year = year;
        }

        //---------------------------Methods---------------------------
        public override string ToString()
        {
            return $"{Manufacturer} - {Model} - {Year}";
        }
    }
}
