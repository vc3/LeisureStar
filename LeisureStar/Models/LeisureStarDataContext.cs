using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using ExoModel.EntityFramework;
using ExoModel;
using ExoRule;
using ExoRule.DataAnnotations;

namespace LeisureStar.Models
{
	public class LeisureStarDataContext : DbContext
	{
		static IRuleProvider annotationRules = new AnnotationsRuleProvider(typeof(Player).Assembly);

		public DbSet<Team> Teams { get; set; }
		public DbSet<Player> Players { get; set; }
		public DbSet<Score> Scores { get; set; }
		public DbSet<Game> Games { get; set; }
		public DbSet<Gender> Genders { get; set; }
		public DbSet<Account> Accounts { get; set; }
		public static LeisureStarDataContext Current
		{
			get
			{
				return (LeisureStarDataContext)((EntityFrameworkModelTypeProvider.EntityModelType)ModelContext.Current.GetModelType<Team>()).GetObjectContext();
			}
		}
	}
}