using System;
using System.Collections.Generic;
using System.Text;

namespace FootballTeamGenerator
{
    public class Team
    {
        public Team(string name)
        {
            this.Name = name;
            players = new List<Player>();
        }
        private string name;
        private List<Player> players;
        public int Rating
        {
            get 
            {
                int sum = 0;
                foreach (var player in players)
                {
                    sum += player.AvaregeStat;
                }
                if (players.Count == 0)
                {
                    return 0;
                }
                return sum/players.Count;
            }
        }
        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception("A name should not be empty.");
                }
                name = value;
            }
        }
        public void AddPlayer(Player player) 
        {
            players.Add(player);
        }
        public void RemovePlayer(string playername) 
        {
            foreach (var player in players)
            {
                if (player.Name == playername)
                {
                    players.Remove(player);
                    return;
                }
            }
            Console.WriteLine($"Player {playername} is not in {this.Name} team.");
        }
    }

}
