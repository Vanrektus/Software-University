using Gym.Models.Athletes.Contracts;
using Gym.Utilities.Messages;
using System;

namespace Gym.Models.Athletes
{
    public abstract class Athlete : IAthlete
    {
        private string fullName;
        private string motivation;
        private int numberOfMedals;

        public string FullName
        {
            get
            { 
                return fullName;
            }

            private set 
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidAthleteName);
                }

                fullName = value;
            }
        }

        public string Motivation
        {
            get 
            {
                return motivation; 
            }

            private set 
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidAthleteMotivation);
                }

                motivation = value; 
            }
        }

        public int Stamina { get; protected set; }

        public int NumberOfMedals
        {
            get 
            {
                return numberOfMedals;
            }

            private  set 
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidAthleteMedals);
                }

                numberOfMedals = value; 
            }
        }

        protected Athlete(string fullName, string motivation, int numberOfMedals, int stamina)
        {
            this.FullName = fullName;
            this.Motivation = motivation;
            this.NumberOfMedals = numberOfMedals;
            this.Stamina = stamina;
        }

        public abstract void Exercise();

        public override string ToString()
        {
            return this.FullName;
        }
    }
}
