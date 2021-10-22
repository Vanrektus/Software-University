using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheRace
{
    public class Race
    {
        //---------------------------Fields---------------------------
        private readonly List<Racer> racers;

        //---------------------------Properties---------------------------
        public string Name { get; set; }

        public int Capacity { get; set; }

        public int Count => racers.Count;

        //---------------------------Constructors---------------------------
        public Race(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.racers = new List<Racer>();
        }

        //---------------------------Methods---------------------------
        public void Add(Racer racer)
        {
            if (racers.Count < Capacity)
            {
                racers.Add(racer);
            }
        }

        public bool Remove(string name)
        {
            Racer racer = racers.FirstOrDefault(r => r.Name == name);

            if (racer != null)
            {
                racers.Remove(racer);
                return true;
            }

            return false;
        }

        public Racer GetOldestRacer()
        {
            return racers.OrderByDescending(r => r.Age).FirstOrDefault();
        }

        public Racer GetRacer(string name)
        {
            return racers.FirstOrDefault(r => r.Name == name);
        }

        public Racer GetFastestRacer()
        {
            return racers.OrderByDescending(r => r.Car.Speed).FirstOrDefault();
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Racers participating at {this.Name}:");

            foreach (Racer currentRacer in racers)
            {
                sb.AppendLine(currentRacer.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
