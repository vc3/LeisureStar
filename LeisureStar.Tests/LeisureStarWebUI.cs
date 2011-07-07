using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VC3.AutomatedTesting.Testables.WebUI;
using VC3.AutomatedTesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WatiN.Core;
using System.Xml;
using System.Text.RegularExpressions;
using Find = VC3.AutomatedTesting.Testables.WebUI.Find;
using Page = VC3.AutomatedTesting.Testables.WebUI.Page;
using VC3.AutomatedTesting.Testables.Database;

namespace LeisureStar.Tests
{
	public class LeisureStarWebUI : TestableWebUI
	{
		LeisureStarDatabase DB;

		public LeisureStarWebUI(Uri url, BrowserVisibility visibility, LeisureStarDatabase db)
			: base(url, visibility)
		{
			this.DB = db;
		}

		#region Overrides
		protected override void OnCleanUp()
		{
			base.OnCleanUp();
		}
		#endregion

		#region Helpers
		/// <summary>
		/// 
		/// </summary>
		/// <param name="url"></param>
		/// <param name="key"></param>
		/// <returns></returns>
		protected static string GetQueryStringParam(string url, string key)
		{
			Regex expr = new Regex("(?:&|\\?)" + key + "=(?<" + key + ">[a-zA-Z0-9\\-]*)");

			if (expr.IsMatch(url))
				return expr.Match(url).Groups[key].Value;

			return null;
		}
		#endregion
	}
}
