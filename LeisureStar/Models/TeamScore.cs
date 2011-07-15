using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LeisureStar.Models
{
	public class TeamScore
	{
		public int Id { get; set; }
		public Game Game { get; set; }
		public Team Team { get; set; }
		public int Score { get; set; }

		public static TeamScore[] All
		{
			get
			{
				return DataContext.Current.TeamScores.ToArray();
			}
		}
	}
}