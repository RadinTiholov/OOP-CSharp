using System;
using System.Collections.Generic;

namespace FootballTeamGenerator
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Team> teams = new List<Team>();
            string input = Console.ReadLine();
            while (input != "END")
            {
                var splitted = input.Split(";");
                string command = splitted[0];
                if (command == "Team")
                {
                    Team team = null;
                    try
                    {
                        team = new Team(splitted[1]);
                        teams.Add(team);
                    }
                    catch (Exception ex )
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else if (command == "Add")
                {
                    bool isFound = false;
                    foreach (var team in teams)
                    {
                        if (team.Name == splitted[1])
                        {
                            Player player = null;
                            try
                            {
                                player = new Player(splitted[2], int.Parse(splitted[3]), int.Parse(splitted[4]), int.Parse(splitted[5]), int.Parse(splitted[6]), int.Parse(splitted[7]));
                                team.AddPlayer(player);
                                isFound = true;
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                                isFound = true;
                            }
                        }
                    }
                    if (!isFound)
                    {
                        Console.WriteLine($"Team {splitted[1]} does not exist.");
                    }
                }
                else if (command == "Remove")
                {
                    foreach (var team in teams)
                    {
                        if (team.Name == splitted[1])
                        {
                            team.RemovePlayer(splitted[2]);
                        }
                    }
                }
                else if (command == "Rating")
                {
                    bool isFound = false;
                    foreach (var team in teams)
                    {
                        if (team.Name == splitted[1])
                        {
                            Console.WriteLine($"{team.Name} - {team.Rating}");
                            isFound = true;
                        }
                    }
                    if (isFound == false)
                    {
                        Console.WriteLine($"Team {splitted[1]} does not exist.");
                    }
                }
                input = Console.ReadLine();
            }
        }
    }
}
