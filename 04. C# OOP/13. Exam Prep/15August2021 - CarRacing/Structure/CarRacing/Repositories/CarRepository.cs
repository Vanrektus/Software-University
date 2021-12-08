using CarRacing.Models.Cars.Contracts;
using CarRacing.Repositories.Contracts;
using CarRacing.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CarRacing.Repositories
{
    public class CarRepository : IRepository<ICar>
    {
        private readonly List<ICar> availableCars;

        public IReadOnlyCollection<ICar> Models => this.availableCars.AsReadOnly();

        public ICar First { get; internal set; }

        public CarRepository()
        {
            this.availableCars = new List<ICar>();
        }

        public void Add(ICar model)
        {
            if (model == null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidAddCarRepository);
            }

            this.availableCars.Add(model);
        }

        public bool Remove(ICar model) => this.availableCars.Remove(model);

        // ???
        public ICar FindBy(string property) => this.availableCars.FirstOrDefault(x => x.VIN == property);
    }
}
