using System;
using System.Collections.Generic;
using System.Linq;

namespace TeamworkProjects
{
    class Program
    {
        static void Main(string[] args)
        {
            TeamList teamList = new TeamList();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] newTeam = Console.ReadLine()
                    .Split('-', StringSplitOptions.RemoveEmptyEntries);

                Team currentTeam = new Team
                {
                    Creator = newTeam[0],
                    TeamName = newTeam[1],
                    Members = new List<string>()
                };

                if (teamList.Teams.Any(x => x.TeamName == newTeam[1]))
                {
                    Console.WriteLine($"Team {newTeam[1]} was already created!");
                    continue;
                }

                if (teamList.Teams.Any(x => x.Creator == newTeam[0]))
                {
                    Console.WriteLine($"{newTeam[0]} cannot create another team!");
                    continue;
                }

                teamList.Teams.Add(currentTeam);
                Console.WriteLine($"Team {newTeam[1]} has been created by {newTeam[0]}!");
            }

            while (true)
            {
                string[] input = Console.ReadLine()
                .Split("->", StringSplitOptions.RemoveEmptyEntries);

                if (input[0] == "end of assignment")
                {
                    break;
                }

                if (!teamList.Teams.Any(x => x.TeamName == input[1]))
                {
                    Console.WriteLine($"Team {input[1]} does not exist!");
                    continue;
                }

                if (teamList.Teams.Any(x => x.Creator == input[0]) 
                    || teamList.Teams.Any(x => x.Members.Contains(input[0])))
                {
                    Console.WriteLine($"Member {input[0]} cannot join team {input[1]}!");
                    continue;
                }

                if (teamList.Teams.Any(x => x.TeamName == input[1]))
                {
                    var existingTeam = teamList.Teams.First(x => x.TeamName == input[1]);

                    existingTeam.Members.Add(input[0]);
                }
            }

            List<string> teamsToDisband = teamList.Teams
                .Where(x => x.Members.Count == 0)
                .Select(x => x.TeamName)
                .ToList();

            foreach (var team in teamList.Teams.OrderByDescending(x => x.Members.Count)
                .ThenBy(x => x.TeamName))
            {
                if (team.Members.Count == 0)
                {
                    continue;
                }

                Console.WriteLine(team.TeamName);
                Console.WriteLine($"- {team.Creator}");

                foreach (var name in team.Members.OrderBy(x => x))
                {
                    Console.WriteLine($"-- {name}");
                }
            }

            Console.WriteLine("Teams to disband:");

            foreach (var item in teamsToDisband.OrderBy(x => x))
            {
                Console.WriteLine(item);
            }
        }
    }

    class Team
    {
        public string Creator { get; set; }
        public string TeamName { get; set; }
        public List<string> Members { get; set; }
    }

    class TeamList
    {
        public List<Team> Teams { get; set; }

        public TeamList()
        {
            Teams = new List<Team>();
        }
    }
}
