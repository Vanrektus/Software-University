using Easter.Models.Bunnies.Contracts;
using Easter.Models.Dyes.Contracts;
using Easter.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Easter.Models.Bunnies
{
    public abstract class Bunny : IBunny
    {
        private string name;
        private int energy;

        public string Name
        {
            get 
            {
                return name; 
            }

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidBunnyName);
                }

                name = value; 
            }
        }

        public int Energy
        {
            get
            {
                return energy;
            }

            protected set
            {
                if (value < 0)
                {
                    energy = 0;
                }
                else
                {
                    energy = value;
                }
            }
        }

        public ICollection<IDye> Dyes { get; }

        protected Bunny(string name, int energy)
        {
            this.Name = name;
            this.Energy = energy;
            this.Dyes = new List<IDye>();
        }

        public virtual void Work()
        {
            this.Energy -= 10;

            IDye dye = this.Dyes.First();
            dye.Use();

            if (dye.IsFinished())
            {
                this.Dyes.Remove(dye);
            }
        }

        public void AddDye(IDye dye) => this.Dyes.Add(dye);
    }
}
