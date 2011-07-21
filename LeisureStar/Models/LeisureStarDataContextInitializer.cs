using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using ExoGraph;
using ExoRule;
using ExoRule.DataAnnotations;
using System.Data.Entity;

namespace LeisureStar.Models
{
	public class LeisureStarDataContextInitializer : DropCreateDatabaseAlways<LeisureStarDataContext>
	{
		public LeisureStarDataContextInitializer()
			: base()
		{
		}

		protected override void Seed(LeisureStarDataContext context)
		{
			//create list of teams
			List<Team> teams = new List<Team>
			{
				new Team { Name="Team 1",
						   Wins = 0,
						   Players = new List<Player>()
				},
				new Team { Name="Team 2",
						   Wins = 0,
						   Players = new List<Player>()
				},
				new Team { Name="Team 3",
						   Wins = 0,
						   Players = new List<Player>()
				},
				new Team { Name="Team 4",
						   Wins = 0,
						   Players = new List<Player>()
				}
			};

			//create list of players
			List<Player> players = new List<Player>
			{
				new Player { FirstName = "Babe",
							 LastName = "Ruth",
							 Gender = "Male",
							 Wins = 0,
							 HasWon = false,
							 Teams = new List<Team>() },
				new Player { FirstName = "Jackie",
							 LastName = "Robinson",
							 Gender = "Male",
							 Wins = 0,
							 HasWon = false,
							 Teams = new List<Team>() },
				new Player { FirstName = "Kirby",
							 LastName = "Puckett",
							 Gender = "Male",
							 Wins = 0,
							 HasWon = false,
							 Teams = new List<Team>() },
				new Player { FirstName = "Cal",
							 LastName = "Ripken Jr",
							 Gender = "Male",
							 Wins = 0,
							 HasWon = false,
							 Teams = new List<Team>() },
				new Player { FirstName = "Lou",
							 LastName = "Gehrig",
							 Gender = "Male",
							 Wins = 0,
							 HasWon = false,
							 Teams = new List<Team>() },
				new Player { FirstName = "Ty",
							 LastName = "Cobb",
							 Gender = "Male",
							 Wins = 0,
							 HasWon = false,
							 Teams = new List<Team>() },
				new Player { FirstName = "Barry",
							 LastName = "Bonds",
							 Gender = "Male",
							 Wins = 0,
							 HasWon = false,
							 Teams = new List<Team>() },
				new Player { FirstName = "Nolan",
							 LastName = "Ryan",
							 Gender = "Male",
							 Wins = 0,
							 HasWon = false,
							 Teams = new List<Team>() }
			};

			//match up players and teams
			//teams[0].Players.Add(players[0]);
			//teams[0].Players.Add(players[1]);
			//players[0].Teams.Add(teams[0]);
			//players[1].Teams.Add(teams[0]);

			//teams[1].Players.Add(players[2]);
			//teams[1].Players.Add(players[3]);
			//players[2].Teams.Add(teams[1]);
			//players[3].Teams.Add(teams[1]);

			//teams[2].Players.Add(players[4]);
			//teams[2].Players.Add(players[5]);
			//players[4].Teams.Add(teams[2]);
			//players[5].Teams.Add(teams[2]);

			//teams[3].Players.Add(players[6]);
			//teams[3].Players.Add(players[7]);
			//players[6].Teams.Add(teams[3]);
			//players[7].Teams.Add(teams[3]);

			players.ForEach(p => context.Players.Add(p));
			teams.ForEach(t => context.Teams.Add(t));
			base.Seed(context);
		}
	}
}