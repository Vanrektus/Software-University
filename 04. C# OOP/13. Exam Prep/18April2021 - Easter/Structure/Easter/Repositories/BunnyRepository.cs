using Easter.Models.Bunnies.Contracts;
using Easter.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace Easter.Repositories
{
    public class BunnyRepository : IRepository<IBunny>
    {
        private readonly List<IBunny> availableBunnies;

        public IReadOnlyCollection<IBunny> Models => this.availableBunnies.AsReadOnly();

        public BunnyRepository()
        {
            this.availableBunnies = new List<IBunny>();
        }

        public void Add(IBunny model) => this.availableBunnies.Add(model);

        public bool Remove(IBunny model) => this.availableBunnies.Remove(model);


        // ???
        public IBunny FindByName(string name) => this.availableBunnies.FirstOrDefault(x => x.Name == name);
    }
}
