using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StreetRacing
{
    public class Race
    {
        //---------------------------Properties---------------------------
        public List<Car> Participants { get; private set; }

        public string Name { get; private set; }

        public string Type { get; private set; }

        public int Laps { get; private set; }

        public int Capacity { get; private set; }

        public int MaxHorsePower { get; private set; }

        public int Count => Participants.Count;

        //---------------------------Constructors---------------------------
        public Race(string name, string type, int laps, int capacity, int maxHorsePower)
        {
            Name = name;
            Type = type;
            Laps = laps;
            Capacity = capacity;
            MaxHorsePower = maxHorsePower;
            Participants = new List<Car>();
        }

        //---------------------------Methods---------------------------
        public void Add(Car car)
        {
            //bool carExists = false;

            //foreach (Car currentCar in Participants)
            //{
            //    if (currentCar.LicensePlate == car.LicensePlate)
            //    {
            //        carExists = true;
            //    }
            //}

            if (Participants.Count < Capacity && car.HorsePower <= MaxHorsePower)// && !carExists)
            {
                Participants.Add(car);
            }
        }

        public bool Remove(string licensePlate)
        {
            Car car = Participants.FirstOrDefault(c => c.LicensePlate == licensePlate);

            if (car != null)
            {
                Participants.Remove(car);
                return true;
            }

            return false;
        }

        public Car FindParticipant(string licensePlate)
        {
            return Participants.FirstOrDefault(c => c.LicensePlate == licensePlate);
        }

        public Car GetMostPowerfulCar()
        {
            return Participants.OrderByDescending(c => c.LicensePlate).FirstOrDefault();
        }

        public string Report()
        {
            if (Participants.Count > 0)
            {
                StringBuilder sb = new StringBuilder();

                sb.AppendLine($"Race: {Name} - Type: {Type} (Laps: {Laps})");

                foreach (Car currentCar in Participants)
                {
                    sb.AppendLine(currentCar.ToString());
                }

                return sb.ToString().TrimEnd();
            }

            return null;
        }
    }
}
