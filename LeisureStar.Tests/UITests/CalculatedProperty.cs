using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VC3.AutomatedTesting;
using WatiN.Core;
using LeisureStar.Tests.Pages;
using LeisureStar.Tests;

namespace LeisureStar.Tests.UITests
{
	/// <summary>
	/// Summary description for test_CalculatedProperty
	/// </summary>
	[TestClass]
	public class CalculatedProperty : BaseUITest
	{
		public CalculatedProperty()
		{
		}

		[TestMethod]
		public void TestPropertiesSameLevelInObjectHierarchy()
		{
			Example2Page page = Context.GoTo<Example2Page>();
			
			//testing the calculated full name property.
			//set the first and last name and verify that full name
			//now has the correct value.
			page.SetValue(page.FirstNameText, "TestFirst");
			page.SetValue(page.LastNameText, "TestLast");
			Assert.AreEqual("TestFirst TestLast", page.FulltNameText.Text);
		}
	}
}
