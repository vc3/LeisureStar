using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using ExoGraph;
using ExoRule;
using ExoRule.DataAnnotations;

namespace LeisureStarLevel2.Models
{
	public class Player
	{
		public int PlayerId { get; set; }

		public virtual ICollection<Team> Teams { get; set; }

		[Required]
		public string FirstName { get; set; }

		[Required]
		public string LastName { get; set; }

		[Required]
		public string Gender { get; set; }

		[NotMapped]
		public bool HasWon { get { return Wins > 0; } }

		[NotMapped]
		public int Wins 
		{
			get
			{
				return ((List<Team>)Teams).Sum(t => t.Wins);
			}
		}

		public static Player[] All
		{
			get
			{
				return LeisureStarDataContext.Current.Players.ToArray();
			}
		}
	}
}