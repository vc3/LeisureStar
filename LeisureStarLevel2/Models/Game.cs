using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using ExoGraph;
using ExoRule;
using ExoRule.DataAnnotations;

namespace LeisureStarLevel2.Models
{
	public class Game
	{
		public int GameId { get; set; }

		public virtual ICollection<Score> Scores { get; set; }

		[Required]
		public string Name { get; set; }

		[Required]
		public DateTime Started { get; set; }

		public DateTime Finished { get; set; }

		[NotMapped]
		public Team Winner
		{
			get
			{
				var maxTeamScore = Scores.Where(ts => ts.Value == Scores.Max(scores => scores.Value));
				if(maxTeamScore.Count() > 0)
				{
					return maxTeamScore.First().Team;
				}
				else
					return null;
			}
		}

		public static Game[] All
		{
			get
			{
				return LeisureStarDataContext.Current.Games.ToArray();
			}
		}
	}
}