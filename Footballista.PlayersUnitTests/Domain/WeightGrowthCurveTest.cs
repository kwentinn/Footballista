using Footballista.BuildingBlocks.Domain.ValueObjects;
using Footballista.Players.Evolutions;
using Footballista.Players.Persons;
using Footballista.Units;
using Footballista.Units.Masses;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Footballista.PlayersUnitTests.Domain
{
	[TestClass]
	public class WeightGrowthCurveTest
	{
		[TestMethod]
		public void MyTestMethod()
		{
			var a = new WeightGrowthCurve(new Percentile(1), new Country("FR"), Gender.Male, SystemOfUnitsType.Imperial, new List<MassGrowth>
			{
				new MassGrowth(1, new Pound(20)),
				new MassGrowth(2, new Pound(25)),
				new MassGrowth(3, new Pound(35)),
			});

			Assert.IsNotNull(a);
		}
	}
}
