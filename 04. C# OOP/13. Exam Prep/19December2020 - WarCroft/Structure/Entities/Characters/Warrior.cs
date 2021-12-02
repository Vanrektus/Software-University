using System;
using WarCroft.Constants;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Inventory.Bags;

namespace WarCroft.Entities.Characters
{
    public class Warrior : Character, IAttacker
    {
        private const double baseHealthWarrior = 100;
        private const double baseArmorWarrior = 50;
        private const double abilityPointsWarrior = 40;

        public Warrior(string name)
            : base(name, baseHealthWarrior, baseArmorWarrior, abilityPointsWarrior, new Satchel())
        {

        }

        public void Attack(Character character)
        {
            this.EnsureAlive();

            if (this.Equals(character))
            {
                throw new InvalidOperationException(ExceptionMessages.CharacterAttacksSelf);
            }

            character.TakeDamage(abilityPointsWarrior);
        }
    }
}
