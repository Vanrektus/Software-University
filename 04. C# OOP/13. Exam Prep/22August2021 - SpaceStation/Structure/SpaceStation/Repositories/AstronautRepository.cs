using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace SpaceStation.Repositories
{
    public class AstronautRepository : IRepository<IAstronaut>
    {
        private readonly List<IAstronaut> availableAstronauts;

        public IReadOnlyCollection<IAstronaut> Models => this.availableAstronauts.AsReadOnly();

        public AstronautRepository()
        {
            this.availableAstronauts = new List<IAstronaut>();
        }

        public void Add(IAstronaut model) => this.availableAstronauts.Add(model);

        public bool Remove(IAstronaut model) => this.availableAstronauts.Remove(model);

        // ??? Not sure if right ???
        public IAstronaut FindByName(string name) => this.availableAstronauts.FirstOrDefault(x => x.Name == name);
    }
}
