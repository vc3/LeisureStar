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
		#region Properties
		
		public int TeamId { get; set; }

		public virtual ICollection<Score> Scores { get; set; }

		public virtual ICollection<Game> Games { get; set; }

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

		[NotMapped]
		public int TotalScore
		{
			get
			{
				return Scores.Sum(s => s.Value);
			}
		}

		public static Team[] All
		{
			get
			{
				return LeisureStarDataContext.Current.Teams.ToArray();
			}
		}

		#endregion

		#region Methods

		/// <summary>
		/// Deletes an instance of the current Player
		/// </summary>
		public void DeleteInstance()
		{
			LeisureStarDataContext.Current.Teams.Remove(this);
			LeisureStarDataContext.Current.SaveChanges();
		}

		#endregion
	}
}