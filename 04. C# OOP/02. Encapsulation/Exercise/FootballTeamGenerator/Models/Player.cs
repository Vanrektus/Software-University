using System;

namespace FootballTeamGenerator
{
    public class Player
    {
        //---------------------------Fields---------------------------
        private string name;

        //---------------------------Properties---------------------------
        public string Name
        {
            get => this.name;

            private set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("A name should not be empty.");
                }

                this.name = value;
            }
        }

        public Stats Stats { get; set; }

        public double Skill => (this.Stats.Endurance + this.Stats.Sprint + this.Stats.Dribble + this.Stats.Passing + this.Stats.Shooting) / 5.0;

        //---------------------------Constructors---------------------------
        public Player(string name, Stats stats)
        {
            this.Name = name;
            this.Stats = stats;
        }
    }
}
