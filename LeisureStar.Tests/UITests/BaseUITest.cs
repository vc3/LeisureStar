using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VC3.AutomatedTesting;
using WatiN.Core;
using LeisureStar.Tests.Pages;
using LeisureStar.Tests;
using System.Configuration;
using VC3.AutomatedTesting.Testables.WebUI;

namespace LeisureStar.Tests.UITests
{
	public abstract class BaseUITest : TestsBase
	{
		#region Properties

		public LeisureStarWebUI Context { get; private set; }
		public LeisureStarDatabase DB { get; private set; }
		#endregion

		public BaseUITest()
		{
			DB = new LeisureStarDatabase(ConfigurationManager.ConnectionStrings["LeisureStarLevel1"].ConnectionString);

			string visibilityConfig = ConfigurationManager.AppSettings["BrowserVisibility"];
			BrowserVisibility visibility = !string.IsNullOrEmpty(visibilityConfig) ? (BrowserVisibility)Enum.Parse(typeof(BrowserVisibility), visibilityConfig) : BrowserVisibility.VisibleIfDebugging;
			Context = this.RegisterTestable(new LeisureStarWebUI(new Uri(ConfigurationManager.AppSettings["ApplicationBaseUrl"]), visibility, DB));
		}
	}
}
