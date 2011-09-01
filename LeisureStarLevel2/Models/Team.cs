using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using ExoGraph;
using ExoRule;
using ExoRule.DataAnnotations;

namespace LeisureStarLevel2.Models
{
	public class Team
	{
		public int TeamId { get; set; }

		public virtual ICollection<Score> Scores { get; set; }

		[Required]
		public string Name { get; set; }

		public virtual ICollection<Player> Players { get; set; }

		[NotMapped]
		public int Wins 
		{
			get
			{
				int tempCount = 0;
				//get the games the team has participated in and sum the wins
				foreach(Game g in LeisureStarDataContext.Current.Games)
				{
					if(g.Winner == this)
						tempCount++;
				}

				return tempCount;
			}
		}

		public static Team[] All
		{
			get
			{
				return LeisureStarDataContext.Current.Teams.ToArray();
			}
		}
	}
}