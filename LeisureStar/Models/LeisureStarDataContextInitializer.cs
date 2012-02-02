using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using ExoModel;
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
			base.Seed(context);
		}
	}
}