using Easter.Core.Contracts;
using Easter.Models.Bunnies;
using Easter.Models.Bunnies.Contracts;
using Easter.Models.Dyes;
using Easter.Models.Eggs;
using Easter.Models.Eggs.Contracts;
using Easter.Models.Workshops;
using Easter.Repositories;
using Easter.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Easter.Core
{
    public class Controller : IController
    {
        private readonly BunnyRepository availableBunnies;
        private readonly EggRepository availableEggs;
        private readonly Workshop workshop;

        public Controller()
        {
            this.availableBunnies = new BunnyRepository();
            this.availableEggs = new EggRepository();
            this.workshop = new Workshop();
        }

        // 3 tests passed (32/150)
        public string AddBunny(string bunnyType, string bunnyName)
        {
            Bunny bunny = default;

            switch (bunnyType)
            {
                case nameof(HappyBunny):
                    bunny = new HappyBunny(bunnyName);

                    this.availableBunnies.Add(bunny);
                    break;
                case nameof(SleepyBunny):
                    bunny = new SleepyBunny(bunnyName);

                    this.availableBunnies.Add(bunny);
                    break;
                default:
                    throw new InvalidOperationException(ExceptionMessages.InvalidBunnyType);
            }

            return string.Format(OutputMessages.BunnyAdded, bunnyType, bunnyName);
        }

        // 2 more tests passed(53/150)
        public string AddDyeToBunny(string bunnyName, int power)
        {
            Dye dye = new Dye(power);

            IBunny bunny = this.availableBunnies.Models
                .FirstOrDefault(x => x.Name == bunnyName);

            if (bunny == null)
            {
                throw new InvalidOperationException(ExceptionMessages.InexistentBunny);
            }

            bunny.AddDye(dye);

            return string.Format(OutputMessages.DyeAdded, power, bunnyName);
        }

        // 2 more tests passed(75/150)
        public string AddEgg(string eggName, int energyRequired)
        {
            IEgg egg = new Egg(eggName, energyRequired);

            this.availableEggs.Add(egg);

            return string.Format(OutputMessages.EggAdded, eggName);
        }

        // 6 more tests passed(139/150)
        public string ColorEgg(string eggName)
        {
            IEgg egg = this.availableEggs.Models.FirstOrDefault(x => x.Name == eggName);

            List<IBunny> bunnies = this.availableBunnies.Models
                .Where(x => x.Energy >= 50)
                .OrderByDescending(x => x.Energy)
                .ToList();

            if (bunnies.Count == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.BunniesNotReady);
            }

            while (egg.IsDone() == false && bunnies.Count > 0)
            {
                IBunny bunny = bunnies.First();
                this.workshop.Color(egg, bunny);

                if (bunny.Dyes.Count == 0)
                {
                    bunnies.Remove(bunny);
                }

                if (bunny.Energy == 0)
                {
                    bunnies.Remove(bunny);
                    this.availableBunnies.Remove(bunny);
                }
            }

            return egg.IsDone() ? string.Format(OutputMessages.EggIsDone, eggName) : string.Format(OutputMessages.EggIsNotDone, eggName);
        }

        // 1 more tests passed(150/150)
        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append($"{this.availableEggs.Models.Count(x => x.IsDone())} eggs are done!" + Environment.NewLine);
            sb.Append($"Bunnies info:" + Environment.NewLine);

            foreach (IBunny currentBunny in this.availableBunnies.Models)
            {
                sb.Append($"Name: {currentBunny.Name}" + Environment.NewLine);
                sb.Append($"Energy: {currentBunny.Energy}" + Environment.NewLine);
                sb.Append($"Dyes: {currentBunny.Dyes.Count} not finished" + Environment.NewLine);
            }

            return sb.ToString().TrimEnd();

            throw new NotImplementedException();
        }
    }
}
