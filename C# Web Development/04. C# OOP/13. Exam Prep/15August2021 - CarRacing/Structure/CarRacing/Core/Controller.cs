using CarRacing.Core.Contracts;
using CarRacing.Models.Cars;
using CarRacing.Models.Cars.Contracts;
using CarRacing.Models.Maps;
using CarRacing.Models.Racers;
using CarRacing.Models.Racers.Contracts;
using CarRacing.Repositories;
using CarRacing.Utilities.Messages;
using System;
using System.Linq;
using System.Text;

namespace CarRacing.Core
{
    public class Controller : IController
    {
        private CarRepository availableCars;
        private RacerRepository availableRacers;
        private Map map;

        public Controller()
        {
            this.availableCars = new CarRepository();
            this.availableRacers = new RacerRepository();
            this.map = new Map();
        }

        // 2 tests passed (14/150) with 0 implemented methods

        // 7 more tests passed (64/150)
        public string AddCar(string type, string make, string model, string VIN, int horsePower)
        {
            Car car = default;

            switch (type)
            {
                case nameof(SuperCar):
                    car = new SuperCar(make, model, VIN, horsePower);

                    this.availableCars.Add(car);
                    break;
                case nameof(TunedCar):
                    car = new TunedCar(make, model, VIN, horsePower);

                    this.availableCars.Add(car);
                    break;
                default:
                    throw new ArgumentException(ExceptionMessages.InvalidCarType);
            }

            return string.Format(OutputMessages.SuccessfullyAddedCar, make, model, VIN);
        }

        // 4 more tests passed (92/150)
        public string AddRacer(string type, string username, string carVIN)
        {
            Racer racer = default;
            ICar car = this.availableCars.Models.FirstOrDefault(x => x.VIN == carVIN);

            if (car == null)
            {
                throw new ArgumentException(ExceptionMessages.CarCannotBeFound);
            }

            switch (type)
            {
                case nameof(ProfessionalRacer):
                    racer = new ProfessionalRacer(username, car);

                    this.availableRacers.Add(racer);
                    break;
                case nameof(StreetRacer):
                    racer = new StreetRacer(username, car);

                    this.availableRacers.Add(racer);
                    break;
                default:
                    throw new ArgumentException(ExceptionMessages.InvalidRacerType);
            }

            return string.Format(OutputMessages.SuccessfullyAddedRacer, racer.Username);
        }

        public string BeginRace(string racerOneUsername, string racerTwoUsername)
        {
            IRacer racerOne = this.availableRacers.Models.FirstOrDefault(x => x.Username == racerOneUsername);
            IRacer racerTwo = this.availableRacers.Models.FirstOrDefault(x => x.Username == racerTwoUsername);

            if (racerOne == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.RacerCannotBeFound, racerOneUsername));
            }
            else if (racerTwo == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.RacerCannotBeFound, racerTwoUsername));
            }
            else
            {
                return this.map.StartRace(racerOne, racerTwo);
            }
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            foreach (IRacer currentRacer in this.availableRacers.Models.OrderByDescending(x => x.DrivingExperience).ThenBy(x => x.Username))
            {
                sb.Append($"{currentRacer.GetType().Name}: {currentRacer.Username}" + Environment.NewLine);
                sb.Append($"--Driving behavior: {currentRacer.RacingBehavior}" + Environment.NewLine);
                sb.Append($"--Driving experience: {currentRacer.DrivingExperience}" + Environment.NewLine);
                sb.Append($"--Car: {currentRacer.Car.Make} {currentRacer.Car.Model} ({currentRacer.Car.VIN})" + Environment.NewLine);
            }

            return sb.ToString().TrimEnd();
        }

        // 1 test didn't pass (142/150)
    }
}
