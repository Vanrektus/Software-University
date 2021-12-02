using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using WarCroft.Constants;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Inventory.Bags
{
    public abstract class Bag : IBag
    {
        private const int capacityDefault = 100;

        private IList<Item> internalItems;

        public int Capacity { get; set; }

        public int Load => Items.Sum(i => i.Weight);
        //public int Load { get => Items.Sum(i => i.Weight); }

        public IReadOnlyCollection<Item> Items { get; }
        //public IReadOnlyCollection<Item> Items => internalItems.AsReadOnly();

        //Constructor
        protected Bag(int capacity)
        {
            this.Capacity = capacity;
            this.internalItems = new List<Item>();
            this.Items = new ReadOnlyCollection<Item>(internalItems);
        }

        public void AddItem(Item item)
        {
            if (this.Load + item.Weight > this.Capacity)
            {
                throw new InvalidOperationException(ExceptionMessages.ExceedMaximumBagCapacity);
            }

            this.internalItems.Add(item);
        }

        public Item GetItem(string name)
        {
            if (this.Items.Count == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.EmptyBag);
            }

            Item foundItem = this.Items
                .FirstOrDefault(i => i.GetType().Name == name);

            if (foundItem == null)
            {
                throw new ArgumentException(ExceptionMessages.ItemNotFoundInBag, name);
            }

            this.internalItems.Remove(foundItem);

            return foundItem;
        }
    }
}
