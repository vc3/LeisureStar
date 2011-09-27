using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using ExoGraph;
using System.Reflection;
using ExoGraph.EntityFramework;
using LeisureStar.Models;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Diagnostics;

namespace LeisureStar
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
			routes.IgnoreRoute("{*allsvc}", new { allsvc = @".*\.svc(/.*)?" });

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
				Assembly coreAssembly = typeof(LeisureStar.Models.Player).Assembly;
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
			SeedDatabase();
		}

		private void SeedDatabase()
		{
			//System.Diagnostics.Debugger.Launch();
			List<Gender> genders = new List<Gender>
			{
				new Gender { Name="Male"
				},
				new Gender { Name="Female"
				},
			};

			genders.ForEach(g => LeisureStarDataContext.Current.Genders.Add(g));
			LeisureStarDataContext.Current.SaveChanges();

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
							 Teams = new List<Team>() },
				new Player { FirstName = "Jackie",
							 LastName = "Robinson",
							 Teams = new List<Team>() },
				new Player { FirstName = "Kirby",
							 LastName = "Puckett",
							 Teams = new List<Team>() },
				new Player { FirstName = "Cal",
							 LastName = "Ripken Jr",
							 Teams = new List<Team>() },
				new Player { FirstName = "Lou",
							 LastName = "Gehrig",
							 Teams = new List<Team>() },
				new Player { FirstName = "Ty",
							 LastName = "Cobb",
							 Teams = new List<Team>() },
				new Player { FirstName = "Barry",
							 LastName = "Bonds",
							 Teams = new List<Team>() },
				new Player { FirstName = "Nolan",
							 LastName = "Ryan",

							 Teams = new List<Team>() }
			};

			genders[0].Players.Add(players[0]);
			genders[0].Players.Add(players[1]);
			genders[0].Players.Add(players[2]);
			genders[0].Players.Add(players[3]);
			genders[0].Players.Add(players[4]);
			genders[0].Players.Add(players[5]);
			genders[0].Players.Add(players[6]);
			genders[0].Players.Add(players[7]);

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
						   NumberOfTeamsPlaying = 2,
						   NumberOfPlayersPerTeam = 2,
						   Scores = new List<Score>()
				},
				new Game { Name = "Game2",
						   Started = new DateTime(2011, 7, 1, 14, 0, 0),
						   Finished = new DateTime(2011, 7, 1, 15, 0, 0),
						   NumberOfTeamsPlaying = 2,
						   NumberOfPlayersPerTeam = 2,
						   Scores = new List<Score>()
				},
				new Game { Name = "Game3",
						   Started = new DateTime(2011, 7, 1, 16, 0, 0),
						   Finished = new DateTime(2011, 7, 1, 17, 0, 0),
						   NumberOfTeamsPlaying = 2,
						   NumberOfPlayersPerTeam = 2,
						   Scores = new List<Score>()
				},
				new Game { Name = "Game4",
						   Started = new DateTime(2011, 7, 1, 17, 0, 0),
						   Finished = new DateTime(2011, 7, 1, 18, 0, 0),
						   NumberOfTeamsPlaying = 2,
						   NumberOfPlayersPerTeam = 2,
						   Scores = new List<Score>()
				},
				new Game { Name = "Game5",
						   Started = null,
						   Finished = null,
						   NumberOfTeamsPlaying = 2,
						   NumberOfPlayersPerTeam = 2,
						   Scores = new List<Score>()
				}
			};

			List<Score> scores = new List<Score>
			{
				new Score {
					Value = 1
				},
				new Score {
					Value = 1
				},
				new Score {
					Value = 1
				},
				new Score {
					Value = 1
				},
				new Score {
					Value = 1
				},
				new Score {
					Value = 1
				},
				new Score {
					Value = 1
				},
				new Score {
					Value = 1
				},
				new Score {
					Value = 1
				},
				new Score {
					Value = 1
				},
				new Score {
					Value = 1
				},
				new Score {
					Value = 1
				}
			};

			//game 1
			games[0].Teams.Add(teams[0]);
			games[0].Teams.Add(teams[1]);

			games[0].Scores.Add(scores[0]);
			teams[0].Scores.Add(scores[0]);
			players[0].Scores.Add(scores[0]);

			games[0].Scores.Add(scores[1]);
			teams[0].Scores.Add(scores[1]);
			players[1].Scores.Add(scores[1]);

			games[0].Scores.Add(scores[2]);
			teams[1].Scores.Add(scores[2]);
			players[2].Scores.Add(scores[2]);

			//game 2
			games[1].Teams.Add(teams[0]);
			games[1].Teams.Add(teams[1]);

			games[1].Scores.Add(scores[3]);
			teams[0].Scores.Add(scores[3]);
			players[1].Scores.Add(scores[3]);

			games[1].Scores.Add(scores[4]);
			teams[1].Scores.Add(scores[4]);
			players[2].Scores.Add(scores[4]);

			games[1].Scores.Add(scores[5]);
			teams[1].Scores.Add(scores[5]);
			players[3].Scores.Add(scores[5]);

			//game 3
			games[2].Teams.Add(teams[2]);
			games[2].Teams.Add(teams[3]);

			games[2].Scores.Add(scores[6]);
			teams[2].Scores.Add(scores[6]);
			players[4].Scores.Add(scores[6]);

			games[2].Scores.Add(scores[7]);
			teams[2].Scores.Add(scores[7]);
			players[5].Scores.Add(scores[7]);

			games[2].Scores.Add(scores[8]);
			teams[3].Scores.Add(scores[8]);
			players[7].Scores.Add(scores[8]);

			//game 4
			games[3].Teams.Add(teams[2]);
			games[3].Teams.Add(teams[3]);

			games[3].Scores.Add(scores[9]);
			teams[2].Scores.Add(scores[9]);
			players[4].Scores.Add(scores[9]);

			games[3].Scores.Add(scores[10]);
			teams[3].Scores.Add(scores[10]);
			players[6].Scores.Add(scores[10]);

			games[3].Scores.Add(scores[11]);
			teams[3].Scores.Add(scores[11]);
			players[7].Scores.Add(scores[11]);

			//game 5 (uncompleted game)
			games[4].Teams.Add(teams[0]);
			games[4].Teams.Add(teams[1]);

			games.ForEach(g => LeisureStarDataContext.Current.Games.Add(g));

			try
			{
				LeisureStarDataContext.Current.SaveChanges();
			}
			catch (DbEntityValidationException dbEx)
			{
				// Creates the text file that the trace listener will write to.
				System.IO.FileStream myTraceLog = new System.IO.FileStream("C:\\Projects\\VC3.Public\\LeisureStar\\LeisureStarDataValidationErrorLog.txt", System.IO.FileMode.OpenOrCreate);
				
				// Creates the new trace listener.
				System.Diagnostics.TextWriterTraceListener myListener = new System.Diagnostics.TextWriterTraceListener(myTraceLog);
				System.Diagnostics.Trace.Listeners.Add(myListener);

				foreach (var validationErrors in dbEx.EntityValidationErrors)
				{
					foreach (var validationError in validationErrors.ValidationErrors)
					{
						Trace.TraceInformation("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
					}
				}

				Trace.Close();
			}
		}
	}
}
