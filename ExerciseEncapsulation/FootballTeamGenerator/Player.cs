using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace FootballTeamGenerator
{
    public class Player
    {
        public Player(string name, params int[] stats)
        {
            this.Name = name;
            this.Stats = stats;
            stats = new int[5];
        }
        private string[] statsNames = { "Endurance", "Sprint", "Dribble", "Passing", "Shooting"};
        private string name;
        private int[] stats;

        public int[] Stats
        {
            get { return stats; }
            private set 
            {
                for (int i = 0; i < value.Length; i++)
                {
                    if (value[i] > 100 || value[i] < 0)
                    {
                        throw new Exception($"{statsNames[i]} should be between 0 and 100.");
                    }
                }
                stats = value;
            }
        }
        public int AvaregeStat 
        {
            get { return (int)Math.Ceiling((double)stats.Sum()/5); }
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

    }
}
