using Footballista.BuildingBlocks.Domain.ValueObjects;
using Footballista.Players.Evolutions;
using Footballista.Players.Persons;
using Footballista.Units;
using Footballista.Units.Lengths;
using Footballista.Units.Masses;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Footballista.PlayersUnitTests.Domain
{
	[TestClass]
	public class GrowthCurveTest
	{
		//[TestMethod]
		//public void New()
		//{
		//	var gc = new GrowthCurve(new Country("FR"), Gender.Male, new List<Growth>()
		//	{
		//		new Growth(1, new Kilogram(5)),
		//		new Growth(1, new Meter(5)),
		//	});
		//	Assert.IsNotNull(gc);
		//}

		[TestMethod]
		public void New_StatureGrowthCurve()
		{
			var hgc = new StatureGrowthCurve
			(
				new Percentile(1),
				new Country("US"),
				Gender.Female,
				SystemOfUnitsType.Imperial,
				new List<LengthGrowth>()
				{
					new LengthGrowth(1, new Meter(0.2)),
					new LengthGrowth(2, new Meter(0.3)),
				}
			);
		}
		[TestMethod]
		public void New_WeightGrowthCurve()
		{
			var hgc = new WeightGrowthCurve
			(
				new Percentile(1),
				new Country("US"),
				Gender.Female,
				SystemOfUnitsType.Imperial,
				new List<MassGrowth>()
				{
					new MassGrowth(1, new Kilogram(0.2)),
					new MassGrowth(2, new Kilogram(0.3)),
				}
			);
		}
	}
}
