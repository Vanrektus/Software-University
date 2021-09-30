namespace PokemonTrainer
{
    public class Pokemon
    {
        //---------------------------Properties---------------------------
        public string Name { get; private set; }
        public string Element { get; private set; }
        public int Health { get; set; }

        //---------------------------Constructors---------------------------
        public Pokemon(string name, string element, int health)
        {
            this.Name = name;
            this.Element = element;
            this.Health = health;
        }
    }
}
