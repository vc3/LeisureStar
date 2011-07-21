using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using ExoGraph;
using ExoRule;
using ExoRule.DataAnnotations;

namespace LeisureStar.Models
{
	public class Team
	{
		public int TeamId { get; set; }
		public string Name { get; set; }
		public virtual ICollection<Player> Players { get; set; }
		public int Wins { get; set; }

		public static Team[] All
		{
			get
			{
				return LeisureStarDataContext.Current.Teams.ToArray();
			}
		}
	}
}