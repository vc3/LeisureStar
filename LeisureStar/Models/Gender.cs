using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using ExoModel;
using ExoRule;
using ExoRule.DataAnnotations;

namespace LeisureStar.Models
{
	[ModelReferenceFormat("[Name]")]
	public class Gender
	{
		#region Properties

		public int GenderId { get; set; }

		[Required]
		public string Name { get; set; }

		public virtual ICollection<Player> Players { get; set; }

		public static ICollection<Gender> All
		{
			get
			{
				return LeisureStarDataContext.Current.Genders.ToArray();
			}
		}

		#endregion
	}
}