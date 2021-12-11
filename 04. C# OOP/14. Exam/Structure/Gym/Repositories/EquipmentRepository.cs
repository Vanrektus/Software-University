using Gym.Models.Equipment.Contracts;
using Gym.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace Gym.Repositories
{
    public class EquipmentRepository : IRepository<IEquipment>
    {
        private List<IEquipment> availableEquipment;

        public IReadOnlyCollection<IEquipment> Models => this.availableEquipment.AsReadOnly();

        public EquipmentRepository()
        {
            this.availableEquipment = new List<IEquipment>();
        }

        public void Add(IEquipment model) => this.availableEquipment.Add(model);

        public bool Remove(IEquipment model) => this.availableEquipment.Remove(model);

        // ??? Potential bug ???
        public IEquipment FindByType(string type) => this.availableEquipment.FirstOrDefault(x => x.GetType().Name == type);
    }
}
