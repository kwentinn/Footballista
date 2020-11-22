using Footballista.BuildingBlocks.Domain.KNNs;
using Footballista.BuildingBlocks.Domain.KNNs.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Footballista.BuildingBlocks.Domain.UnitTests
{
	[TestClass]
	public class KNearestNeighborCalculatorUnitTest
	{
		[TestMethod]
		public void Search_001()
		{
			var nnc = new KNearestNeighborCalculator(10, new int[] { 1, 5, 9, 13, 18, 25 });

			List<KnnResult<int>> result = nnc.Search();

			Assert.IsNotNull(result);
			Assert.IsTrue(result.Count == 1);
			Assert.AreEqual(9, result[0].Value);
		}

		[TestMethod]
		public void Search_002()
		{
			var nnc = new KNearestNeighborCalculator(10, new int[] { 1, 5, 9, 13, 18, 25 }, 3);

			List<KnnResult<int>> result = nnc.Search();

			Assert.IsNotNull(result);
			Assert.IsTrue(result.Count == 3);
			Assert.AreEqual(9, result[0].Value);
			Assert.AreEqual(13, result[1].Value);
			Assert.AreEqual(5, result[2].Value);
		}

		[TestMethod]
		public void Search_003()
		{
			var k = 4;

			var nnc = new KNearestNeighborCalculator
			(
				x: 500,
				data: new int[] 
				{ 
					-5, -2, 0, 1, 150, 200, -5, 156155, 
					565, 5, 9, 13, 18, 25, 65655, 522, 441, 884, 599, 511,
					490, 510, 501, 502, 499
				}, 
				k: k
			);

			List<KnnResult<int>> result = nnc.Search();

			Assert.IsNotNull(result);
			Assert.IsTrue(result.Count == k);
			Assert.AreEqual(501, result[0].Value);
			Assert.AreEqual(499, result[1].Value);
			Assert.AreEqual(502, result[2].Value);
			Assert.AreEqual(490, result[3].Value);
		}
	}
}
