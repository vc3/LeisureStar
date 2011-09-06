﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using ExoGraph;
using ExoRule;
using ExoRule.DataAnnotations;

namespace LeisureStar.Models
{
	public class Gender
	{
		public int GenderId { get; set; }

		[Required]
		public string Name { get; set; }

		public virtual ICollection<Player> Players { get; set; }

		public static Gender[] All
		{
			get
			{
				return LeisureStarDataContext.Current.Genders.ToArray();
			}
		}


	}
}