using SpaceStation.Core.Contracts;
using SpaceStation.Models.Astronauts;
using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Mission;
using SpaceStation.Models.Planets;
using SpaceStation.Models.Planets.Contracts;
using SpaceStation.Repositories;
using SpaceStation.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceStation.Core
{
    public class Controller : IController
    {
        private AstronautRepository availableAstronauts;
        private PlanetRepository availablePlanets;
        private Mission mission;

        private int exploredPlantes = 0;

        public Controller()
        {
            this.availableAstronauts = new AstronautRepository();
            this.availablePlanets = new PlanetRepository();
            this.mission = new Mission();
        }

        // 4 tests passed
        // ??? must add astronaut to repository ???
        public string AddAstronaut(string type, string astronautName)
        {
            Astronaut astronaut = default;

            switch (type)
            {
                case nameof(Biologist):
                    astronaut = new Biologist(astronautName);
                    availableAstronauts.Add(astronaut);
                    break;
                case nameof(Geodesist):
                    astronaut = new Geodesist(astronautName);
                    availableAstronauts.Add(astronaut);
                    break;
                case nameof(Meteorologist):
                    astronaut = new Meteorologist(astronautName);
                    availableAstronauts.Add(astronaut);
                    break;
                default:
                    throw new InvalidOperationException(ExceptionMessages.InvalidAstronautType);
            }

            return string.Format(OutputMessages.AstronautAdded, type, astronautName);
        }

        // 4 more tests passed
        public string AddPlanet(string planetName, params string[] items)
        {
            Planet planet = new Planet(planetName);

            foreach (string currentItem in items)
            {
                planet.Items.Add(currentItem);
            }

            availablePlanets.Add(planet);

            return string.Format(OutputMessages.PlanetAdded, planetName);
        }

        // 2 more tests passed
        public string RetireAstronaut(string astronautName)
        {
            IAstronaut astronaut = availableAstronauts.Models.FirstOrDefault(x => x.Name == astronautName);

            if (astronaut == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidRetiredAstronaut, astronautName));
            }

            this.availableAstronauts.Remove(astronaut);

            return string.Format(OutputMessages.AstronautRetired, astronautName);
        }

        // ??? Potential bug ???
        // 2 more tests passed
        public string ExplorePlanet(string planetName)
        {
            List<IAstronaut> astronautsToExplore = new List<IAstronaut>();

            foreach (IAstronaut currentAstronaut in this.availableAstronauts.Models.Where(x => x.Oxygen > 60))
            {
                astronautsToExplore.Add(currentAstronaut);
            }

            if (astronautsToExplore.Count == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAstronautCount);
            }

            IPlanet planet = this.availablePlanets.Models.FirstOrDefault(x => x.Name == planetName);

            this.mission.Explore(planet, astronautsToExplore);

            int deadAstronauts = astronautsToExplore.Where(x => x.Oxygen == 0).Count();
            this.exploredPlantes++;

            return string.Format(OutputMessages.PlanetExplored, planetName, deadAstronauts);
        }

        // 1 more test passed
        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append($"{this.exploredPlantes} planets were explored!" + Environment.NewLine);
            sb.Append("Astronauts info:" + Environment.NewLine);

            foreach (IAstronaut currentAstronaut in this.availableAstronauts.Models)
            {
                sb.Append($"Name: {currentAstronaut.Name}" + Environment.NewLine);
                sb.Append($"Oxygen: {currentAstronaut.Oxygen}" + Environment.NewLine);

                if (currentAstronaut.Bag.Items.Count > 0)
                {
                    sb.Append($"Bag items: {string.Join(", ", currentAstronaut.Bag.Items)}" + Environment.NewLine);
                }
                else
                {
                    sb.Append($"Bag items: none" + Environment.NewLine);
                }
            }

            return sb.ToString().TrimEnd();
        }

        // !!! EVERYTHING PASSED !!!
    }
}
