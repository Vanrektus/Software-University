using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SkiRental
{
    public class SkiRental
    {
        //---------------------------Properties---------------------------
        public List<Ski> Data { get; private set; }

        public string Name { get; set; }

        public int Capacity { get; set; }

        public int Count => Data.Count;

        //---------------------------Constructors---------------------------
        public SkiRental(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            Data = new List<Ski>();
        }

        //---------------------------Methods---------------------------
        public void Add(Ski ski)
        {
            if (Data.Count < Capacity)
            {
                Data.Add(ski);
            }
        }

        public bool Remove(string manufacturer, string model)
        {
            Ski ski = Data.FirstOrDefault(s => s.Manufacturer == manufacturer && s.Model == model);

            if (ski != null)
            {
                Data.Remove(ski);
                return true;
            }

            return false;
        }

        public Ski GetNewestSki()
        {
            return Data.OrderByDescending(s => s.Year).FirstOrDefault();
        }

        public Ski GetSki(string manufacturer, string model)
        {
            return Data.FirstOrDefault(s => s.Manufacturer == manufacturer && s.Model == model);
        }

        public string GetStatistics()
        {
            if (Data.Count > 0)
            {
                StringBuilder sb = new StringBuilder();

                sb.AppendLine($"The skis stored in {Name}:");

                foreach (Ski currentSki in Data)
                {
                    sb.AppendLine(currentSki.ToString());
                }

                return sb.ToString().TrimEnd();
            }

            return null;
        }
    }
}
