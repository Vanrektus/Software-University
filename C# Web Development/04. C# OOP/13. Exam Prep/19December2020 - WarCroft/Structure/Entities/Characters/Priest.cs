using System;
using WarCroft.Constants;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Inventory.Bags;

namespace WarCroft.Entities.Characters
{
    public class Priest : Character, IHealer
    {
        private const double baseHealthPriest = 50;
        private const double baseArmorPriest = 25;
        private const double abilityPointsPriest = 40;

        public Priest(string name)
            : base(name, baseHealthPriest, baseArmorPriest, abilityPointsPriest, new Backpack())
        {

        }

        public void Heal(Character character)
        {
            this.EnsureAlive();

            if (character.IsAlive == false)
            {
                throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
            }

            character.Health += this.AbilityPoints;
        }
    }
}
