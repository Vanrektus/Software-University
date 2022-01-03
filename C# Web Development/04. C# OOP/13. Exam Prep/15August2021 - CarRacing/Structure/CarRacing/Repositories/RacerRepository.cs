using CarRacing.Models.Racers.Contracts;
using CarRacing.Repositories.Contracts;
using CarRacing.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CarRacing.Repositories
{
    public class RacerRepository : IRepository<IRacer>
    {
        private readonly List<IRacer> availableRacers;

        public IReadOnlyCollection<IRacer> Models => this.availableRacers.AsReadOnly();

        public RacerRepository()
        {
            this.availableRacers = new List<IRacer>();
        }

        public void Add(IRacer model)
        {
            if (model == null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidAddRacerRepository);
            }

            this.availableRacers.Add(model);
        }

        public bool Remove(IRacer model) => this.availableRacers.Remove(model);

        // ???
        public IRacer FindBy(string property) => this.availableRacers.FirstOrDefault(x => x.Username ==  property);
    }
}
