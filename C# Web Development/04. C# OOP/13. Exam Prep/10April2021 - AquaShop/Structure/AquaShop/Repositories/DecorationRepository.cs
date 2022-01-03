using AquaShop.Models.Decorations.Contracts;
using AquaShop.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace AquaShop.Repositories
{
    public class DecorationRepository : IRepository<IDecoration>
    {
        private List<IDecoration> availableDecorations;

        public IReadOnlyCollection<IDecoration> Models => this.availableDecorations.AsReadOnly();

        public DecorationRepository()
        {
            this.availableDecorations = new List<IDecoration>();
        }

        public void Add(IDecoration model) => this.availableDecorations.Add(model);

        public bool Remove(IDecoration model) => this.availableDecorations.Remove(model);

        // ??? Not sure if right ???
        public IDecoration FindByType(string type) => this.availableDecorations.FirstOrDefault(x => x.GetType().Name == type);
    }
}
