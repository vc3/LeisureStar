using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using ExoGraph;
using ExoRule;
using ExoRule.DataAnnotations;

namespace LeisureStarLevel2.Models
{
	public class Score
	{
		public int ScoreId { get; set; }

		public virtual Game Game { get; set; }

		public virtual Team Team { get; set; }

		public int Value { get; set; }

		public static Score[] All
		{
			get
			{
				return LeisureStarDataContext.Current.Scores.ToArray();
			}
		}
	}
}