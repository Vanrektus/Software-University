using System;
using System.Linq;

namespace Raiding
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            BaseHero[] raidGroup = new BaseHero[n];

            int createdHeroes = 0;

            while (createdHeroes != n)
            {
                string heroName = Console.ReadLine();
                string heroType = Console.ReadLine();

                switch (heroType)
                {
                    case "Druid":
                        BaseHero currentDruid = new Druid(heroName);

                        raidGroup[createdHeroes] = currentDruid;

                        createdHeroes++;
                        break;

                    case "Paladin":
                        BaseHero currentPaladin = new Paladin(heroName);

                        raidGroup[createdHeroes] = currentPaladin;

                        createdHeroes++;
                        break;

                    case "Rogue":
                        BaseHero currentRogue = new Rogue(heroName);

                        raidGroup[createdHeroes] = currentRogue;

                        createdHeroes++;
                        break;

                    case "Warrior":
                        BaseHero currentWarrior = new Warrior(heroName);

                        raidGroup[createdHeroes] = currentWarrior;

                        createdHeroes++;
                        break;

                    default:
                        Console.WriteLine("Invalid hero!");
                        break;
                }
            }

            int bossPower = int.Parse(Console.ReadLine());

            foreach (BaseHero currentHero in raidGroup)
            {
                Console.WriteLine(currentHero.CastAbility());
            }

            if (raidGroup.Sum(x => x.Power) >= bossPower)
            {
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine("Defeat...");
            }
        }
    }
}
