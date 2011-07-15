using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using ExoGraph;
using ExoRule;
using ExoRule.DataAnnotations;

namespace LeisureStar.Models
{
	public class Game
	{
		public int Id { get; set; }
		public ICollection<TeamScore> TeamScores { get; set; }
		public Team Winner { get; set; }
		public DateTime Started { get; set; }
		public DateTime Finished { get; set; }

		public static Game[] All
		{
			get
			{
				return DataContext.Current.Games.ToArray();
			}
		}
	}
}