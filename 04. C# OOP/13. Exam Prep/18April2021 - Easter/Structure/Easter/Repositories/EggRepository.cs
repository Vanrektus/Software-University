using Easter.Models.Eggs.Contracts;
using Easter.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace Easter.Repositories
{
    public class EggRepository : IRepository<IEgg>
    {
        private readonly List<IEgg> availableEggs;

        public IReadOnlyCollection<IEgg> Models => this.availableEggs.AsReadOnly();

        public EggRepository()
        {
            this.availableEggs = new List<IEgg>();
        }

        public void Add(IEgg model) => this.availableEggs.Add(model);

        public bool Remove(IEgg model) => this.availableEggs.Remove(model);

        // ???
        public IEgg FindByName(string name) => this.availableEggs.FirstOrDefault(x => x.Name == name);
    }
}
