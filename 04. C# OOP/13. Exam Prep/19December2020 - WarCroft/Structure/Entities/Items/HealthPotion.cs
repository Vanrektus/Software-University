using WarCroft.Entities.Characters.Contracts;

namespace WarCroft.Entities.Items
{
    public class HealthPotion : Item
    {
        private const int healthPotionWeight = 5;
        private const double characterHealthIncrease = 20;

        public HealthPotion()
            : base(healthPotionWeight)
        {

        }

        public override void AffectCharacter(Character character)
        {
            base.AffectCharacter(character);

            character.Health += characterHealthIncrease;
        }
    }
}
