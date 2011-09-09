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
		#region Properties

		public int GameId { get; set; }

		public virtual ICollection<Score> Scores { get; set; }

		[ListLength("NumberOfTeamsPlaying", ExoRule.Validation.CompareOperator.Equal)]
		public virtual ICollection<Team> Teams { get; set; }

		[Required]
		public string Name { get; set; }

		[Required]
		[DisplayFormat(DataFormatString = "ShortDate")]
		public DateTime? Started { get; set; }

		[DisplayFormat(DataFormatString = "ShortDate")]
		public DateTime? Finished { get; set; }

		[Required]
		[Range(1, 10)]
		public int NumberOfTeamsPlaying { get; set; }

		[Required]
		[Range(1, 10)]
		public int NumberOfPlayersPerTeam { get; set; }

		[NotMapped]
		public Team Winner
		{
			get
			{
				int maxTeamScore = 0;
				Team temp = null;

				foreach (Team t in Teams)
				{
					if (Scores.Where(s => s.Team == t && s.Game == this).Sum(s => s.Value) > maxTeamScore)
					{
						maxTeamScore = Scores.Where(s => s.Team == t && s.Game == this).Sum(s => s.Value);
						temp = t;
					}
				}

				return temp;
			}
		}

		public static Game[] All
		{
			get
			{
				return LeisureStarDataContext.Current.Games.ToArray();
			}
		}

		#endregion

		#region Methods
		/// <summary>
		/// Deletes an instance of the current Player
		/// </summary>
		public void DeleteInstance()
		{
			LeisureStarDataContext.Current.Games.Remove(this);
			LeisureStarDataContext.Current.SaveChanges();
		}
		#endregion
	}
}