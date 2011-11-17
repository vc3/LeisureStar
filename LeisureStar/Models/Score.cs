using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using ExoGraph;
using ExoRule;
using ExoRule.DataAnnotations;

namespace LeisureStar.Models
{
	public class Score
	{
		#region Properties

		public int ScoreId { get; set; }

		public virtual Game Game { get; set; }

		public virtual Team Team { get; set; }

		public virtual Player Player { get; set; }

		public int Value { get; set; }

		#endregion
	}
}