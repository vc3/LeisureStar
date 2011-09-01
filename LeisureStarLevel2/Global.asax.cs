using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using ExoGraph;
using System.Reflection;
using ExoGraph.EntityFramework;
using LeisureStarLevel2.Models;
using System.Data.Entity;

namespace LeisureStarLevel2
{
	// Note: For instructions on enabling IIS6 or IIS7 classic mode, 
	// visit http://go.microsoft.com/?LinkId=9394801

	public class MvcApplication : System.Web.HttpApplication
	{
		public static void RegisterGlobalFilters(GlobalFilterCollection filters)
		{
			filters.Add(new HandleErrorAttribute());
		}

		public static void RegisterRoutes(RouteCollection routes)
		{
			routes.IgnoreRoute("{*allHandlers}", new { allHandlers = @".*\.axd(/.*)?" });

			routes.MapRoute(
				"Default", // Route name
				"{controller}/{action}/{id}", // URL with parameters
				new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
			);

		}

		protected void Application_Start()
		{
			//System.Diagnostics.Debugger.Launch();
			new GraphContextProvider().CreateContext += (source, args) =>
			{
				Assembly coreAssembly = typeof(MvcApplication).Assembly;
				args.Context = new GraphContext(new EntityFrameworkGraphTypeProvider(() => new LeisureStarDataContext()));
				ExoRule.Rule.RegisterRules(coreAssembly);
			};

			AreaRegistration.RegisterAllAreas();

			RegisterGlobalFilters(GlobalFilters.Filters);
			RegisterRoutes(RouteTable.Routes);

			ExoWeb.ExoWeb.Adapter = new ExoWeb.DataAnnotations.ServiceAdapter();

			//Rebuild Database from the POCO's and seed the database with test data
			//cannot use the normal method of seeding data by overriding the Seed method
			//of DropCreateDatabaseAlways because the DbContext and GraphContext are
			//so closely coupled.
			Database.SetInitializer<LeisureStarDataContext>(new DropCreateDatabaseAlways<LeisureStarDataContext>());
			SeedDBDatabase();
		}

		private void SeedDBDatabase()
		{
			//System.Diagnostics.Debugger.Launch();
			List<Team> teams = new List<Team>
			{
				new Team { Name="Team 1",
						   Players = new List<Player>()
				},
				new Team { Name="Team 2",
						   Players = new List<Player>()
				},
				new Team { Name="Team 3",
						   Players = new List<Player>()
				},
				new Team { Name="Team 4",
						   Players = new List<Player>()
				}
			};

			//create list of players
			List<Player> players = new List<Player>
			{
				new Player { FirstName = "Babe",
							 LastName = "Ruth",
							 Gender = "Male",
							 Teams = new List<Team>() },
				new Player { FirstName = "Jackie",
							 LastName = "Robinson",
							 Gender = "Male",
							 Teams = new List<Team>() },
				new Player { FirstName = "Kirby",
							 LastName = "Puckett",
							 Gender = "Male",
							 Teams = new List<Team>() },
				new Player { FirstName = "Cal",
							 LastName = "Ripken Jr",
							 Gender = "Male",
							 Teams = new List<Team>() },
				new Player { FirstName = "Lou",
							 LastName = "Gehrig",
							 Gender = "Male",
							 Teams = new List<Team>() },
				new Player { FirstName = "Ty",
							 LastName = "Cobb",
							 Gender = "Male",
							 Teams = new List<Team>() },
				new Player { FirstName = "Barry",
							 LastName = "Bonds",
							 Gender = "Male",
							 Teams = new List<Team>() },
				new Player { FirstName = "Nolan",
							 LastName = "Ryan",
							 Gender = "Male",
							 Teams = new List<Team>() }
			};

			//match up players and teams
			teams[0].Players.Add(players[0]);
			teams[0].Players.Add(players[1]);

			teams[1].Players.Add(players[2]);
			teams[1].Players.Add(players[3]);

			teams[2].Players.Add(players[4]);
			teams[2].Players.Add(players[5]);

			teams[3].Players.Add(players[6]);
			teams[3].Players.Add(players[7]);

			//create team scores/games
			List<Game> games = new List<Game>
			{
				new Game { Name = "Game1",
						   Started = new DateTime(2011, 7, 1, 13, 0, 0),
						   Finished = new DateTime(2011, 7, 1, 14, 0, 0),
						   Scores = new List<Score>()
				},
				new Game { Name = "Game2",
						   Started = new DateTime(2011, 7, 1, 14, 0, 0),
						   Finished = new DateTime(2011, 7, 1, 15, 0, 0),
						   Scores = new List<Score>()
				},
				new Game { Name = "Game3",
						   Started = new DateTime(2011, 7, 1, 16, 0, 0),
						   Finished = new DateTime(2011, 7, 1, 17, 0, 0),
						   Scores = new List<Score>()
				},
				new Game { Name = "Game4",
						   Started = new DateTime(2011, 7, 1, 17, 0, 0),
						   Finished = new DateTime(2011, 7, 1, 18, 0, 0),
						   Scores = new List<Score>()
				},
				new Game { Name = "Game5",
						   Started = new DateTime(2011, 7, 1, 8, 0, 0),
						   Finished = new DateTime(2011, 7, 1, 9, 0, 0),
						   Scores = new List<Score>()
				},
				new Game { Name = "Game6",
						   Started = new DateTime(2011, 7, 1, 10, 0, 0),
						   Finished = new DateTime(2011, 7, 1, 11, 0, 0),
						   Scores = new List<Score>()
				},
				new Game { Name = "Game7",
						   Started = new DateTime(2011, 7, 1, 12, 0, 0),
						   Finished = new DateTime(2011, 7, 1, 13, 0, 0),
						   Scores = new List<Score>()
				},
				new Game { Name = "Game8",
						   Started = new DateTime(2011, 7, 1, 13, 0, 0),
						   Finished = new DateTime(2011, 7, 1, 14, 0, 0),
						   Scores = new List<Score>()
				},
			};

			List<Score> scores = new List<Score>
			{
				new Score {
					Value = 5
				},
				new Score {
					Value = 4
				},
				new Score {
					Value = 0
				},
				new Score {
					Value = 4
				},
				new Score {
					Value = 8
				},
				new Score {
					Value = 1
				},
				new Score {
					Value = 5
				},
				new Score {
					Value = 6
				},
				new Score {
					Value = 5
				},
				new Score {
					Value = 7
				},
				new Score {
					Value = 3
				},
				new Score {
					Value = 4
				},
				new Score {
					Value = 2
				},
				new Score {
					Value = 19
				},
				new Score {
					Value = 5
				},
				new Score {
					Value = 4
				}
			};

			//game 1
			games[0].Scores.Add(scores[0]);
			games[0].Scores.Add(scores[1]);
			teams[0].Scores.Add(scores[0]);
			teams[1].Scores.Add(scores[1]);

			//game 2
			games[1].Scores.Add(scores[2]);
			games[1].Scores.Add(scores[3]);
			teams[0].Scores.Add(scores[2]);
			teams[1].Scores.Add(scores[3]);
			
			//game 3
			games[2].Scores.Add(scores[4]);
			games[2].Scores.Add(scores[5]);
			teams[2].Scores.Add(scores[4]);
			teams[3].Scores.Add(scores[5]);

			//game 4
			games[3].Scores.Add(scores[6]);
			games[3].Scores.Add(scores[7]);
			teams[2].Scores.Add(scores[6]);
			teams[3].Scores.Add(scores[7]);

			//game 5
			games[4].Scores.Add(scores[8]);
			games[4].Scores.Add(scores[9]);
			teams[0].Scores.Add(scores[8]);
			teams[1].Scores.Add(scores[9]);

			//game 6
			games[5].Scores.Add(scores[10]);
			games[5].Scores.Add(scores[11]);
			teams[0].Scores.Add(scores[10]);
			teams[1].Scores.Add(scores[11]);

			//game 7
			games[6].Scores.Add(scores[12]);
			games[6].Scores.Add(scores[13]);
			teams[2].Scores.Add(scores[12]);
			teams[3].Scores.Add(scores[13]);

			//game 8
			games[7].Scores.Add(scores[14]);
			games[7].Scores.Add(scores[15]);
			teams[2].Scores.Add(scores[14]);
			teams[3].Scores.Add(scores[15]);

			games.ForEach(g => LeisureStarDataContext.Current.Games.Add(g));
			LeisureStarDataContext.Current.SaveChanges();
		}
	}
}
