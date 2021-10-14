using System;
using System.Collections.Generic;
using System.Linq;

namespace PokemonTrainer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Trainer> trainers = new List<Trainer>();

            while (true)
            {
                string[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (input[0] == "Tournament")
                {
                    break;
                }

                string trainerName = input[0];
                string pokemonName = input[1];
                string pokemonElement = input[2];
                int pokemonHealth = int.Parse(input[3]);

                Pokemon newPokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);
                Trainer newTrainer = new Trainer(trainerName, new List<Pokemon> { newPokemon });

                if (!trainers.Any(x => x.Name == trainerName))
                {
                    trainers.Add(newTrainer);
                }
                else
                {
                    trainers.FirstOrDefault(x => x.Name == trainerName).Pokemon.Add(newPokemon);
                }
            }

            while (true)
            {
                string elementToCheck = Console.ReadLine();

                if (elementToCheck == "End")
                {
                    break;
                }

                foreach (var currentTrainer in trainers)
                {
                    if (currentTrainer.Pokemon.Any(x => x.Element == elementToCheck))
                    {
                        currentTrainer.NumberOfBadges++;
                    }
                    else
                    {
                        currentTrainer.Pokemon.Select(x => x.Health -= 10).ToList();
                        currentTrainer.Pokemon.RemoveAll(x => x.Health <= 0);
                    }
                }
            }

            trainers = trainers.OrderByDescending(x => x.NumberOfBadges).ToList();

            Console.WriteLine(string.Join(Environment.NewLine, trainers));
        }
    }
}
