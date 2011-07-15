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
	public class DataContext : DbContext
	{
		static IRuleProvider annotationRules = new AnnotationsRuleProvider(typeof(Team).Assembly.GetGraphTypes());

		public DbSet<Team> Teams { get; set; }
		public DbSet<Player> Players { get; set; }
		public DbSet<TeamScore> TeamScores { get; set; }
		public DbSet<Game> Games { get; set; }

		public static DataContext Current
		{
			get
			{
				return (DataContext)((EntityFrameworkGraphTypeProvider.EntityGraphType)GraphContext.Current.GetGraphType<Team>()).GetObjectContext();
			}
		}

		public DataContext()
			: base("DataContext")
		{
			Configuration.LazyLoadingEnabled = true;
		}

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
			modelBuilder.Entity<Team>().HasMany(t => t.Players).WithMany(p => p.Teams);
			modelBuilder.Entity<Game>().HasMany(g => g.TeamScores).WithRequired();
		}
	}
}