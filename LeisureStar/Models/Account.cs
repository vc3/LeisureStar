using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using ExoModel;
using ExoRule;
using ExoRule.DataAnnotations;
using System.Web.Security;

namespace LeisureStar.Models
{
	#region Account Model

	public class Account
	{
		#region Properties

		public int AccountId { get; set; }

		[Required]
		public string UserName { get; set; }

		[Required]
		public string Password { get; set; }

		public static ICollection<Account> All
		{
			get
			{
				return LeisureStarDataContext.Current.Accounts.ToArray();
			}
		}

		#endregion

		#region Methods
		public static bool ValidateUser(string username, string encryptedPassword)
		{
			Account userAccount = (from a in All where a.UserName == username select a).FirstOrDefault();

			if (userAccount != null)
			{
				return userAccount.Password == encryptedPassword;
			}

			return false;
		}
		#endregion
	}
	#endregion
}