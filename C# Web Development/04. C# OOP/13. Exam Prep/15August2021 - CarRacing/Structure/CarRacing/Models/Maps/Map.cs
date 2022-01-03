using CarRacing.Models.Maps.Contracts;
using CarRacing.Models.Racers.Contracts;
using CarRacing.Utilities.Messages;

namespace CarRacing.Models.Maps
{
    public class Map : IMap
    {
        // ??? Potential Bug ???
        public string StartRace(IRacer racerOne, IRacer racerTwo)
        {
            if (racerOne.IsAvailable() == false && racerTwo.IsAvailable() == false)
            {
                return OutputMessages.RaceCannotBeCompleted;
            }
            else if (racerOne.IsAvailable() == false)
            {
                return string.Format(OutputMessages.OneRacerIsNotAvailable, racerTwo.Username, racerOne.Username);
            }
            else if (racerTwo.IsAvailable() == false)
            {
                return string.Format(OutputMessages.OneRacerIsNotAvailable, racerOne.Username, racerTwo.Username);
            }
            else
            {
                double racerOneBehaviorMultiplier = 1;

                if (racerOne.RacingBehavior == "strict")
                {
                    racerOneBehaviorMultiplier = 1.2;
                }
                else if (racerOne.RacingBehavior == "aggressive")
                {
                    racerOneBehaviorMultiplier = 1.1;
                }

                double racerTwoBehaviorMultiplier = 1;

                if (racerTwo.RacingBehavior == "strict")
                {
                    racerTwoBehaviorMultiplier = 1.2;
                }
                else if (racerOne.RacingBehavior == "aggressive")
                {
                    racerTwoBehaviorMultiplier = 1.1;
                }

                int racerOneChanceToWin = (int)(racerOne.Car.HorsePower * racerOne.DrivingExperience * racerOneBehaviorMultiplier);
                int racerTwoChanceToWin = (int)(racerTwo.Car.HorsePower * racerTwo.DrivingExperience * racerTwoBehaviorMultiplier);

                string winnerUsername = racerOneChanceToWin > racerTwoChanceToWin ? racerOne.Username : racerTwo.Username;

                racerOne.Race();
                racerTwo.Race();

                return string.Format(OutputMessages.RacerWinsRace, racerOne.Username, racerTwo.Username, winnerUsername);
            }
        }
    }
}
