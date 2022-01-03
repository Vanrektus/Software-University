using SpaceStation.Models.Planets.Contracts;
using SpaceStation.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace SpaceStation.Repositories
{
    public class PlanetRepository : IRepository<IPlanet>
    {
        private readonly List<IPlanet> availablePlanets;

        public IReadOnlyCollection<IPlanet> Models => this.availablePlanets.AsReadOnly();

        public PlanetRepository()
        {
            this.availablePlanets = new List<IPlanet>();
        }

        public void Add(IPlanet model) => this.availablePlanets.Add(model);

        public bool Remove(IPlanet model) => this.availablePlanets.Remove(model);

        // ??? Not sure if right ???
        public IPlanet FindByName(string name) => this.availablePlanets.FirstOrDefault(x => x.Name == name);
    }
}
