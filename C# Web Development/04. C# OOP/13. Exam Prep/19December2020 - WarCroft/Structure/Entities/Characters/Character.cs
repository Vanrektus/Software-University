using System;
using System.Text;
using WarCroft.Constants;
using WarCroft.Entities.Inventory.Bags;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Characters.Contracts
{
    public abstract class Character
    {
		// TODO: Implement the rest of the class.

		//Fields
		private string name;
		private double health;
		private double armor;

		//Properties
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
					throw new ArgumentException(ExceptionMessages.CharacterNameInvalid);
                }

				name = value;
            }
		}

        public double Health 
		{ 
			get
            {
				return health;
            }

			set
            {
                if (value < 0)
                {
					health = 0;
                }
                else if (value > BaseHealth)
                {
					health = BaseHealth;
                }
                else
                {
					health = value;
                }
            }
		}

        public double BaseHealth { get; }

        public double Armor
		{
			get
			{
				return armor;
			}

			set
			{
				if (value < 0)
				{
					armor = 0;
				}
                else
                {
					armor = value;
                }
			}
		}

        public double BaseArmor { get; }

        public double AbilityPoints { get; set; }

        public Bag Bag { get; }

        public bool IsAlive { get; set; } = true;

		//Constructor
        protected Character(string name, double health, double armor, double abilityPoints, Bag bag)
        {
			this.Name = name;
			this.BaseHealth = health;
			this.Health = health;
			this.BaseArmor = armor;
			this.Armor = armor;
			this.AbilityPoints = abilityPoints;
			this.Bag = bag;
        }

		//Methods
		protected void EnsureAlive()
		{
			if (!this.IsAlive)
			{
				throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
			}
		}

		public void TakeDamage(double hitPoints)
        {
			this.EnsureAlive();

            if (this.Armor - hitPoints >= 0)
            {
				this.Armor -= hitPoints;
            }
            else if (this.Armor - hitPoints < 0)
            {
				double leftHitPoointsToReduceHealth = hitPoints - this.Armor;
				this.Armor = 0;
				this.Health -= leftHitPoointsToReduceHealth;

                if (this.Health == 0)
                {
					this.IsAlive = false;
                }
            }
        }

		public void UseItem(Item item)
        {
			this.EnsureAlive();

			item.AffectCharacter(this);
        }
    }
}