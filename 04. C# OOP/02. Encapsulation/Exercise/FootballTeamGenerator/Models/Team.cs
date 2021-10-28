﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace FootballTeamGenerator
{
    public class Team
    {
        //---------------------------Fields---------------------------
        private string name;
        private readonly List<Player> players;

        //---------------------------Properties---------------------------
        public string Name
        {
            get => this.name;

            private set
            {
                if (String.IsNullOrEmpty(value) || String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("A name should not be empty.");
                }

                this.name = value;
            }
        }

        public IReadOnlyCollection<Player> Players => this.players.AsReadOnly();

        private int Rating => (this.Players.Count != 0) ? (int)Math.Round(this.Players.Sum(p => p.Skill) / this.Players.Count) : 0;


        //---------------------------Constructors---------------------------
        public Team(string name)
        {
            this.Name = name;
            this.players = new List<Player>();
        }

        //---------------------------Methods---------------------------
        public void AddPlayer(Player player)
        {
            this.players.Add(player);
        }

        public void RemovePlayer(string playerName)
        {
            if (!this.Players.Any(p => p.Name == playerName))
            {
                throw new ArgumentException($"Player {playerName} is not in {this.Name} team.");
            }

            this.players.Remove(this.players.FirstOrDefault(p => p.Name == playerName));
        }

        public override string ToString()
        {
            return $"{this.Name} - {this.Rating}";
        }
    }
}
