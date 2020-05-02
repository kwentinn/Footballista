using Footballista.BuildingBlocks.Domain.KNNs;
using Footballista.BuildingBlocks.Domain.KNNs.Models;
using Footballista.BuildingBlocks.Domain.Percentiles;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Footballista.BuildingBlocks.Domain.UnitTests
{
	[TestClass]
	public class PercentileKNearestNeighborCalculatorUnitTest
	{
		[TestMethod]
		public void Search_001()
		{
			var nnc = new PercentileKNearestNeighborCalculator(
				x: new Percentile(11),
				data: new Percentile[] {
					new Percentile(1),
					new Percentile(5),
					new Percentile(9),
					new Percentile(13),
					new Percentile(18),
					new Percentile(25)
				},
				k: 2
			);

			List<KnnResult<Percentile>> result = nnc.Search();

			Assert.IsNotNull(result);
			Assert.IsTrue(result.Count == 2);
			Assert.AreEqual(new Percentile(9), result[0].Value);
			Assert.AreEqual(new Percentile(13), result[1].Value);
		}
	}
}
