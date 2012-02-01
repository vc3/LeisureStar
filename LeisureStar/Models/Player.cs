using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using ExoGraph;
using ExoRule;
using ExoRule.DataAnnotations;

namespace LeisureStar.Models
{
	[GraphReferenceFormat("[FirstName] [LastName]")]
	public class Player
	{
		#region Properties

		public int PlayerId { get; set; }

		public virtual ICollection<Score> Scores { get; set; }

		public virtual ICollection<Team> Teams { get; set; }

		[Required]
		public string FirstName { get; set; }

		[Required]
		[Compare("FirstName", ExoRule.Validation.CompareOperator.NotEqual)]
		public string LastName { get; set; }

		[Required]
		[AllowedValues("Gender.All")]
		public virtual Gender Gender { get; set; }

		[NotMapped]
		public bool HasWon { get { return Wins > 0; } }

		public int Wins { get; set; }

		[NotMapped]
		public int TotalScore
		{
			get
			{
				return Scores.Sum(s => s.Value);
			}
		}

		[NotMapped]
		public string FullName
		{
			get;
			private set;
		}

		public static ICollection<Player> All
		{
			get
			{
				return LeisureStarDataContext.Current.Players.ToArray();
			}
		}

		#endregion

		#region Methods

		/// <summary>
		/// Deletes an instance of the current Player
		/// </summary>
		public void DeleteInstance()
		{
			LeisureStarDataContext.Current.Players.Remove(this);
			LeisureStarDataContext.Current.SaveChanges();
		}

		#endregion

		#region Rules
		static readonly Rule CalculateFullName = new Rule<Player>(
			RuleInvocationType.PropertyGet,
			player =>
			{
				player.FullName = player.FirstName + " " + player.LastName;
			});
		#endregion
	}
}