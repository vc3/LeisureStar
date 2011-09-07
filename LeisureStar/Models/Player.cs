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
		public int PlayerId { get; set; }

		public virtual ICollection<Team> Teams { get; set; }

		[Required]
		public string FirstName { get; set; }

		[Required]
		public string LastName { get; set; }

		[Required]
		[AllowedValues("Gender.All")]
		public virtual Gender Gender { get; set; }

		[NotMapped]
		public bool HasWon { get { return Wins > 0; } }

		public int Wins { get; set; }
		
		public static Player[] All
		{
			get
			{
				return LeisureStarDataContext.Current.Players.ToArray();
			}
		}

		/// <summary>
		/// Deletes an instance of the current Player
		/// </summary>
		public void DeleteInstance()
		{
			LeisureStarDataContext.Current.Players.Remove(this);
			LeisureStarDataContext.Current.SaveChanges();
		}
	}
}