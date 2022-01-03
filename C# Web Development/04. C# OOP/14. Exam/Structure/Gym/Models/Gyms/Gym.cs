using Gym.Models.Athletes.Contracts;
using Gym.Models.Equipment.Contracts;
using Gym.Models.Gyms.Contracts;
using Gym.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gym.Models.Gyms
{
    public abstract class Gym : IGym
    {
        private string name;
        private List<IEquipment> equipment;
        private List<IAthlete> athletes;

        public string Name
        {
            get 
            {
                return name; 
            }

            private set 
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidGymName);
                }

                name = value; 
            }
        }

        public int Capacity { get; private set; }

        public ICollection<IEquipment> Equipment => this.equipment;

        public ICollection<IAthlete> Athletes => this.athletes;

        // ??? Potential bug ???
        public double EquipmentWeight => this.Equipment.Sum(x => x.Weight);

        // ???
        protected Gym(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.equipment = new List<IEquipment>();
            this.athletes = new List<IAthlete>();
        }

        public void AddAthlete(IAthlete athlete)
        {
            if (this.Athletes.Count == this.Capacity)
            {
                throw new InvalidOperationException(ExceptionMessages.NotEnoughSize);
            }

            this.Athletes.Add(athlete);
        }

        // ???
        public bool RemoveAthlete(IAthlete athlete) => this.Athletes.Remove(athlete);

        // ???
        public void AddEquipment(IEquipment equipment) => this.Equipment.Add(equipment);

        public void Exercise()
        {
            foreach (IAthlete currentAthlete in this.Athletes)
            {
                currentAthlete.Exercise();
            }
        }

        public string GymInfo()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{this.Name} is a {this.GetType().Name}:");

            if (this.Athletes.Count > 0)
            {
                // ??? Potential bug ???
                sb.AppendLine($"Athletes: {string.Join(", ", this.Athletes)}");
            }
            else if (this.Athletes.Count == 0)
            {
                // ??? Potential bug ???
                sb.AppendLine("Athletes: No athletes");
            }

            sb.AppendLine($"Equipment total count: {this.Equipment.Count}");
            // ??? Potential bug ???
            sb.AppendLine($"Equipment total weight: {this.Equipment.Sum(x => x.Weight):f2} grams");

            return sb.ToString().TrimEnd();
        }
    }
}
