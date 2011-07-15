using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using ExoGraph;
using ExoRule;
using ExoRule.DataAnnotations;
namespace LeisureStar.Models
{
	public class Player
	{
		public int Id { get; set; }
		public ICollection<Team> Teams { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Gender { get; set; }
		public bool HasWon { get; set; }
		public int Wins { get; set; }

		public static Player[] All
		{
			get
			{
				return DataContext.Current.Players.ToArray();
			}
		}
	}
}