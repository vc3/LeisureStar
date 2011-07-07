using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VC3.AutomatedTesting.Testables.WebUI;
using WatiN.Core;
using WatiN.Core.Constraints;
using Find = VC3.AutomatedTesting.Testables.WebUI.Find;
using Page = VC3.AutomatedTesting.Testables.WebUI.Page;
using System.Text.RegularExpressions;

namespace LeisureStar.Tests.Pages
{
	[Url("Examples/Example2")]
	public class Example2Page : ExoWebPage
	{
		public TextField FirstNameText { get { return Doc.TextField(Find.ByName(new Regex("textFirstName", RegexOptions.IgnoreCase))); } }
		public TextField LastNameText { get { return Doc.TextField(Find.ByName(new Regex("textLastName", RegexOptions.IgnoreCase))); } }
		public TextField FulltNameText { get { return Doc.TextField(Find.ByName(new Regex("textFullName", RegexOptions.IgnoreCase))); } }

		public Example2Page()
		{
		}
	}
}
