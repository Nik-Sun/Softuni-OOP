using System;
using System.Collections.Generic;

namespace FootballTeamGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<Team> teams = new List<Team>();
            while (input != "END")
            {
                string[] data = input.Split(";");
                string command = data[0];
                string teamName = data[1];
                try
                {
                    switch (command)
                    {
                        case "Team":
                            Team team = new Team(data[1]);
                            teams.Add(team);
                            break;
                        case "Add":

                            int index = teams.FindIndex(t => t.Name == teamName);
                            if (index == -1)
                            {
                                Console.WriteLine($"Team {teamName} does not exist.");
                            }
                            else
                            {
                                teams[index].AddPlayer(data[2], int.Parse(data[3]), int.Parse(data[4]), int.Parse(data[5]), int.Parse(data[6]), int.Parse(data[7]));
                            }
                            break;
                        case "Remove":
                            string playerName = data[2];
                            int teamIndex = teams.FindIndex(t => t.Name == teamName);
                            if (teamIndex != -1)
                            {
                                teams[teamIndex].RemovePlayer(playerName);
                            }
                            else
                            {
                                Console.WriteLine($"Team {teamName} does not exist.");
                            }
                            break;
                        case "Rating":
                            index = teams.FindIndex(t => t.Name == teamName);
                            if (index != -1)
                            {
                                Console.WriteLine(teams[index].Rating());
                            }
                            else
                            {
                                Console.WriteLine($"Team {teamName} does not exist.");
                            }
                            break;
                        default:
                            break;
                    }
                }
                catch (Exception e)
                {

                    Console.WriteLine(e.Message);
                }
               
                input = Console.ReadLine();
            }
        }
    }
}
