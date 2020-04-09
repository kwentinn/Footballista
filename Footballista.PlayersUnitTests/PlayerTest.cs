using Footballista.Players;
using Itenso.TimePeriod;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Footballista.PlayersUnitTests
{
	[TestClass]
	public class PlayerTest
	{
		[TestMethod]
		public void MyTestMethod()
		{
			var p = Person.CreateNew
			(
				"José", "Pelé", Gender.Male, new Date(2000, 1, 1), new Location("Carnon", "FR"),
				new System.Globalization.RegionInfo("FR")
			);
		}
	}
}
