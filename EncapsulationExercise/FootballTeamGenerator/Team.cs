using System;
using System.Collections.Generic;
using System.Text;

namespace FootballTeamGenerator
{
    public class Team
    {
        private List<Player> roster;
        private string name;

        public Team(string name)
        {
            Name = name;
            roster = new List<Player>();
        }
        public string Name
        {
            get => name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception("A name should not be empty.");
                }
                name = value;
            }
        }

        public void AddPlayer(string name, int endurance, int sprint, int dribble, int passing, int shooting)
        {
            Player player = new Player(name, endurance, sprint, dribble, passing, shooting);
            roster.Add(player);
        }
        public void RemovePlayer(string name)
        {
            int index = roster.FindIndex(p => p.Name == name);
            if (index == -1)
            {
                Console.WriteLine($"Player {name} is not in {Name} team.");
            }
            else
            {
                roster.RemoveAt(index);
            }


        }
        public string Rating()
        {
            int rating = 0;
            if (roster.Count >0)
            {
                foreach (var player in roster)
                {

                    int skillLevel = (int)Math.Round((player.Endurance + player.Sprint + player.Dribble + player.Passing + player.Shooting) / 5.0);
                    rating += skillLevel;
                }
                return $"{Name} - {Math.Round((double)rating / roster.Count)}";
            }
            else
            {
                return $"{Name} - {rating}";
            }
           

        }

    }
}
