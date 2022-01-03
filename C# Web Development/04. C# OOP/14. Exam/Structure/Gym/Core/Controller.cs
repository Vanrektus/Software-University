using Gym.Core.Contracts;
using Gym.Models.Athletes;
using Gym.Models.Athletes.Contracts;
using Gym.Models.Equipment;
using Gym.Models.Equipment.Contracts;
using Gym.Models.Gyms;
using Gym.Models.Gyms.Contracts;
using Gym.Repositories;
using Gym.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gym.Core
{
    public class Controller : IController
    {
        private EquipmentRepository availableEquipment;
        private ICollection<IGym> gyms;

        public Controller()
        {
            this.availableEquipment = new EquipmentRepository();
            this.gyms = new List<IGym>();
        }

        // 0 tests passed with 0 implementation (0/150)

        // ???
        // 2 more tests passed (13/150)
        public string AddGym(string gymType, string gymName)
        {
            IGym gym = default;

            switch (gymType)
            {
                case nameof(BoxingGym):
                    gym = new BoxingGym(gymName);

                    this.gyms.Add(gym);

                    return string.Format(OutputMessages.SuccessfullyAdded, gymType);

                case nameof(WeightliftingGym):
                    gym = new WeightliftingGym(gymName);

                    this.gyms.Add(gym);

                    return string.Format(OutputMessages.SuccessfullyAdded, gymType);

                default:
                    throw new InvalidOperationException(ExceptionMessages.InvalidGymType);
            }
        }

        // ???
        // 2 more tests passed (27/150)
        public string AddEquipment(string equipmentType)
        {
            IEquipment equipment = default;

            switch (equipmentType)
            {
                case nameof(BoxingGloves):
                    equipment = new BoxingGloves();

                    this.availableEquipment.Add(equipment);

                    return string.Format(OutputMessages.SuccessfullyAdded, equipmentType);

                case nameof(Kettlebell):
                    equipment = new Kettlebell();

                    this.availableEquipment.Add(equipment);

                    return string.Format(OutputMessages.SuccessfullyAdded, equipmentType);

                default:
                    throw new InvalidOperationException(ExceptionMessages.InvalidEquipmentType);
            }            
        }

        // 3 more tests passed (47/150)
        public string InsertEquipment(string gymName, string equipmentType)
        {
            IGym gym = this.gyms.FirstOrDefault(x => x.Name == gymName);

            IEquipment equipment = this.availableEquipment.Models.FirstOrDefault(x => x.GetType().Name == equipmentType);

            if (equipment == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InexistentEquipment, equipmentType));
            }

            gym.Equipment.Add(equipment);
            this.availableEquipment.Remove(equipment);

            return string.Format(OutputMessages.EntityAddedToGym, equipmentType, gymName);

            //throw new NotImplementedException();
        }

        // 8 more tests passed (102/150)
        public string AddAthlete(string gymName, string athleteType, string athleteName, string motivation, int numberOfMedals)
        {
            Athlete athlete = default;
            IGym gym = this.gyms.FirstOrDefault(x => x.Name == gymName);

            switch (athleteType)
            {
                case nameof(Boxer):
                    athlete = new Boxer(athleteName, motivation, numberOfMedals);

                    // ??? Potential bug ???
                    if (gym.GetType().Name == nameof(BoxingGym))
                    {
                        gym.AddAthlete(athlete);

                        return string.Format(OutputMessages.EntityAddedToGym, athleteType, gymName);
                    }
                    else
                    {
                        return OutputMessages.InappropriateGym;
                    }

                case nameof(Weightlifter):
                    athlete = new Weightlifter(athleteName, motivation, numberOfMedals);

                    // ??? Potential bug ???
                    if (gym.GetType().Name == nameof(WeightliftingGym))
                    {
                        gym.AddAthlete(athlete);

                        return string.Format(OutputMessages.EntityAddedToGym, athleteType, gymName);
                    }
                    else
                    {
                        return OutputMessages.InappropriateGym;
                    }

                default:
                    throw new InvalidOperationException(ExceptionMessages.InvalidAthleteType);
            }

            //throw new NotImplementedException();
        }

        // 3 more tests passed (122/150)
        public string TrainAthletes(string gymName)
        {
            IGym gym = this.gyms.FirstOrDefault(x => x.Name == gymName);

            gym.Exercise();

            //Tested
            return string.Format(OutputMessages.AthleteExercise, gym.Athletes.Count);

            //throw new NotImplementedException();
        }

        // 1 more tests passed (129/150)
        public string EquipmentWeight(string gymName)
        {
            IGym gym = this.gyms.FirstOrDefault(x => x.Name == gymName);

            return string.Format(OutputMessages.EquipmentTotalWeight, gymName, gym.EquipmentWeight);

            //throw new NotImplementedException();
        }

        // ???
        // 1 more tests passed (136/150)
        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            foreach (IGym currentGym in this.gyms)
            {
                sb.AppendLine(currentGym.GymInfo());
            }

            return sb.ToString().TrimEnd();

            //throw new NotImplementedException();
        }
    }
}
