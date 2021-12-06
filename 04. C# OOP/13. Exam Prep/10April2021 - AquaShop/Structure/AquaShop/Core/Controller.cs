using AquaShop.Core.Contracts;
using AquaShop.Models.Aquariums;
using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish;
using AquaShop.Models.Fish.Contracts;
using AquaShop.Repositories;
using AquaShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaShop.Core
{
    public class Controller : IController
    {
        private DecorationRepository availableDecorations;
        private List<IAquarium> aquariums;

        public Controller()
        {
            this.availableDecorations = new DecorationRepository();
            this.aquariums = new List<IAquarium>();
        }

        //3 tests passed
        public string AddAquarium(string aquariumType, string aquariumName)
        {
            if (aquariumType != nameof(FreshwaterAquarium) && aquariumType != nameof(SaltwaterAquarium))
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAquariumType);
            }

            Aquarium aquarium = default;

            if (aquariumType == nameof(FreshwaterAquarium))
            {
                aquarium = new FreshwaterAquarium(aquariumName);
            }
            else
            {
                aquarium = new SaltwaterAquarium(aquariumName);
            }

            aquariums.Add(aquarium);

            return string.Format(OutputMessages.SuccessfullyAdded, aquariumType);
        }

        //2 more tests passed
        public string AddDecoration(string decorationType)
        {
            if (decorationType != nameof(Ornament) && decorationType != nameof(Plant))
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidDecorationType);
            }

            Decoration decoration = default;

            if (decorationType == nameof(Ornament))
            {
                decoration = new Ornament();
            }
            else
            {
                decoration = new Plant();
            }

            availableDecorations.Add(decoration);

            return string.Format(OutputMessages.SuccessfullyAdded, decorationType);
        }

        //2 more tests passed
        public string InsertDecoration(string aquariumName, string decorationType)
        {
            IDecoration decoration = this.availableDecorations.FindByType(decorationType);

            if (decoration == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InexistentDecoration, decorationType));
            }

            this.aquariums.FirstOrDefault(x => x.Name == aquariumName).AddDecoration(decoration);
            this.availableDecorations.Remove(decoration);

            return string.Format(OutputMessages.EntityAddedToAquarium, decorationType, aquariumName);
        }

        //9 more tests passed
        public string AddFish(string aquariumName, string fishType, string fishName, string fishSpecies, decimal price)
        {
            if (fishType != nameof(FreshwaterFish) && fishType != nameof(SaltwaterFish))
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidFishType);
            }

            IFish fish = default;
            IAquarium aquarium = this.aquariums.FirstOrDefault(x => x.Name == aquariumName);

            if (fishType == nameof(FreshwaterFish) && aquarium.GetType().Name == nameof(FreshwaterAquarium))
            {
                fish = new FreshwaterFish(fishName, fishSpecies, price);

                aquarium.AddFish(fish);

                return string.Format(OutputMessages.EntityAddedToAquarium, fishType, aquariumName);
            }
            else if (fishType == nameof(SaltwaterFish) && aquarium.GetType().Name == nameof(SaltwaterAquarium))
            {
                fish = new SaltwaterFish(fishName, fishSpecies, price);

                aquarium.AddFish(fish);

                return string.Format(OutputMessages.EntityAddedToAquarium, fishType, aquariumName);
            }
            else
            {
                return OutputMessages.UnsuitableWater;
            }
        }

        //1 more test passed
        public string FeedFish(string aquariumName)
        {
            IAquarium aquarium = this.aquariums.FirstOrDefault(x => x.Name == aquariumName);

            aquarium.Feed();

            return string.Format(OutputMessages.FishFed, aquarium.Fish.Count);
        }

        //1 more test passed
        public string CalculateValue(string aquariumName)
        {
            IAquarium aquarium = this.aquariums.FirstOrDefault(x => x.Name == aquariumName);

            decimal fishPrice = this.aquariums.FirstOrDefault(x => x.Name == aquariumName).Fish.Sum(x => x.Price);
            decimal decorationsPrice = this.aquariums.FirstOrDefault(x => x.Name == aquariumName).Decorations.Sum(x => x.Price);
            decimal totalPrice = fishPrice + decorationsPrice;

            return string.Format(OutputMessages.AquariumValue, aquariumName, totalPrice);
        }

        //0 tests passed
        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            foreach (IAquarium currentAquarium in this.aquariums)
            {
                sb.Append(currentAquarium.GetInfo() + Environment.NewLine);
            }

            return sb.ToString().TrimEnd();
        }
    }
}
