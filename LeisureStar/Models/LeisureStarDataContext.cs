using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using ExoGraph.EntityFramework;
using ExoGraph;
using ExoRule;
using ExoRule.DataAnnotations;

namespace LeisureStar.Models
{
	public class LeisureStarDataContext : DbContext
	{
		//static IRuleProvider annotationRules = new AnnotationsRuleProvider(typeof(Team).Assembly.GetGraphTypes());

		public DbSet<Team> Teams { get; set; }
		public DbSet<Player> Players { get; set; }
		public DbSet<TeamScore> TeamScores { get; set; }
		public DbSet<Game> Games { get; set; }

		public static LeisureStarDataContext Current
		{
			get
			{
				return (LeisureStarDataContext)((EntityFrameworkGraphTypeProvider.EntityGraphType)GraphContext.Current.GetGraphType<Team>()).GetObjectContext();
			}
		}
	}
}