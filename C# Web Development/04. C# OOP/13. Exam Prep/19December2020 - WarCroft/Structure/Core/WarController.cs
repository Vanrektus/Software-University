using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WarCroft.Constants;
using WarCroft.Entities.Characters;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Items;

namespace WarCroft.Core
{
    public class WarController
    {
        private readonly List<Character> characterParty;
        private readonly Stack<Item> itemPool;

        public WarController()
        {
            this.characterParty = new List<Character>();
            this.itemPool = new Stack<Item>();
        }

        public string JoinParty(string[] args)
        {
            string characterType = args[0];
            string name = args[1];

            switch (characterType)
            {
                case "Warrior":
                    characterParty.Add(new Warrior(name));
                    break;
                case "Priest":
                    characterParty.Add(new Priest(name));
                    break;
                default:
                    throw new ArgumentException(ExceptionMessages.InvalidCharacterType, characterType);
            }

            return string.Format(SuccessMessages.JoinParty, name);
        }

        public string AddItemToPool(string[] args)
        {
            string itemName = args[0];

            switch (itemName)
            {
                case "HealthPotion":
                    itemPool.Push(new HealthPotion());
                    break;
                case "FirePotion":
                    itemPool.Push(new FirePotion());
                    break;
                default:
                    throw new ArgumentException(ExceptionMessages.InvalidItem, itemName);
            }

            return string.Format(SuccessMessages.AddItemToPool, itemName);
        }

        public string PickUpItem(string[] args)
        {
            string characterName = args[0];

            Character character = this.characterParty
                .FirstOrDefault(c => c.Name == characterName);

            if (character == null)
            {
                throw new ArgumentException(ExceptionMessages.CharacterNotInParty, characterName);
            }

            if (this.itemPool.Count == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.ItemPoolEmpty);
            }

            Item itemToPick = this.itemPool.Pop();
            character.Bag.AddItem(itemToPick);

            return string.Format(SuccessMessages.PickUpItem, characterName, itemToPick.GetType().Name);
        }

        public string UseItem(string[] args)
        {
            string characterName = args[0];
            string itemName = args[1];

            Character character = this.characterParty
                .FirstOrDefault(c => c.Name == characterName);

            if (character == null)
            {
                throw new ArgumentException(ExceptionMessages.CharacterNotInParty, characterName);
            }

            Item currentItem = character.Bag.GetItem(itemName);
            character.UseItem(currentItem);

            return string.Format(SuccessMessages.UsedItem, characterName, currentItem.GetType().Name);
        }

        public string GetStats()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var currentCharacter in characterParty.OrderByDescending(c => c.IsAlive).ThenByDescending(c => c.Health))
            {
                sb.AppendLine(string.Format(SuccessMessages.CharacterStats,
                    currentCharacter.Name,
                    currentCharacter.Health,
                    currentCharacter.BaseHealth,
                    currentCharacter.Armor,
                    currentCharacter.BaseArmor,
                    currentCharacter.IsAlive ? "Alive" : "Dead"));
            }

            return sb.ToString().TrimEnd();
        }

        public string Attack(string[] args)
        {
            string attackerName = args[0];
            string receiverName = args[1];

            Character attackerCharacter = this.characterParty.FirstOrDefault(c => c.Name == attackerName);

            if (attackerCharacter == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, attackerName));
            }

            Character receiverCharacter = this.characterParty.FirstOrDefault(c => c.Name == receiverName);

            if (receiverCharacter == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, receiverName));
            }

            //if (!(attackerCharacter is IAttacker attacker))
            //{
            //    throw new ArgumentException(string.Format(ExceptionMessages.AttackFail, attackerName));
            //}

            //attacker.Attack(receiverCharacter);

            Warrior warrior = attackerCharacter as Warrior;

            if (warrior == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.AttackFail, attackerName));
            }

            warrior.Attack(receiverCharacter);

            StringBuilder sb = new StringBuilder();

            sb.AppendLine(string.Format(SuccessMessages.AttackCharacter,
                attackerName,
                receiverName,
                attackerCharacter.AbilityPoints,
                receiverName,
                receiverCharacter.Health,
                receiverCharacter.BaseHealth,
                receiverCharacter.Armor,
                receiverCharacter.BaseArmor));

            if (receiverCharacter.Health == 0)
            {
                sb.AppendLine(string.Format(SuccessMessages.AttackKillsCharacter, receiverName));
            }

            return sb.ToString().TrimEnd();
        }

        public string Heal(string[] args)
        {
            string healerName = args[0];
            string healingReceiverName = args[1];

            Character healerCharacter = this.characterParty.FirstOrDefault(c => c.Name == healerName);

            if (healerCharacter == null)
            {
                throw new ArgumentException(ExceptionMessages.CharacterNotInParty, healerName);
            }

            Character healingReceiverCharacter = this.characterParty.FirstOrDefault(c => c.Name == healingReceiverName);

            if (healingReceiverCharacter == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, healingReceiverName));
            }

            //if (!(healerCharacter is IHealer healer))
            //{
            //    throw new ArgumentException(string.Format(ExceptionMessages.HealerCannotHeal, healerName));
            //}

            //healer.Heal(healingReceiverCharacter);

            Priest priest = healerCharacter as Priest;

            if (priest == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.HealerCannotHeal, healerName));
            }

            priest.Heal(healingReceiverCharacter);

            return string.Format(SuccessMessages.HealCharacter,
                healerName,
                healingReceiverName,
                healerCharacter.AbilityPoints,
                healingReceiverName,
                healingReceiverCharacter.Health);
        }
    }
}
