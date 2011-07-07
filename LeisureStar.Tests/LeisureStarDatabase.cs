using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VC3.AutomatedTesting.Testables.Database;

namespace LeisureStar.Tests
{
	public class LeisureStarDatabase: TestableDatabase
	{
		public LeisureStarDatabase(string connectionString)
			:base(connectionString)
		{
		}
	}
}
