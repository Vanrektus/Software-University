using System.Collections.Generic;

namespace PokemonTrainer
{
    public class Trainer
    {
        //---------------------------Properties---------------------------
        public string Name { get; private set; }
        public int NumberOfBadges { get; set; }
        public List<Pokemon> Pokemon { get; private set; }

        //---------------------------Constructors---------------------------
        public Trainer(string name, List<Pokemon> pokemon)
        {
            this.Name = name;
            this.NumberOfBadges = 0;
            this.Pokemon = pokemon;
        }

        public override string ToString()
        {
            return $"{this.Name} {this.NumberOfBadges} {this.Pokemon.Count}";
        }
    }
}
