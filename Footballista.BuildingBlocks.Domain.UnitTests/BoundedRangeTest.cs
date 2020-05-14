using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Footballista.BuildingBlocks.Domain.UnitTests
{
	[TestClass]
	public class BoundedRangeTest
	{
		[TestMethod]
		public void New_PassZeroAsMinAndMaxValues_ShouldThrowBusinessRuleValidationException()
		{
			Assert.ThrowsException<BusinessRuleValidationException>(() =>
			{
				var range = new BoundedRange<int>(0, BoundType.Open, 0, BoundType.Closed);
			});
		}
		[TestMethod]
		public void New_PassZeroAsMinAndMinusOneAsMax_ShouldThrowBusinessRuleValidationException()
		{
			Assert.ThrowsException<BusinessRuleValidationException>(() =>
			{
				var range = new BoundedRange<int>(0, BoundType.Open, -1, BoundType.Open);
			});
		}
		[TestMethod]
		public void New_Pass0AsLowerAnd10AsUpper_ShouldReturnNewInstance()
		{
			var range = new BoundedRange<int>(0, BoundType.Open, 10, BoundType.Closed);

			Assert.IsNotNull(range);
		}
		[TestMethod]
		public void New_Pass0AsLowerAnd10AsUpper_ShouldReturnNewInstance2()
		{
			var range = new BoundedRange<int>(new Bound<int>(0, BoundType.Open), new Bound<int>(10, BoundType.Closed));

			Assert.IsNotNull(range);
		}
		[TestMethod]
		public void IsInRange_()
		{
			var range = new BoundedRange<int>(0, BoundType.Open, 10, BoundType.Closed);

			bool inRange = range.IsValueInRange(5);

			Assert.IsTrue(inRange);
		}
		[TestMethod]
		public void IsInRange_PassLowerLimit_ShouldReturnFalse()
		{
			var range = new BoundedRange<int>(0, BoundType.Open, 10, BoundType.Closed);

			bool inRange = range.IsValueInRange(0);

			Assert.IsFalse(inRange);
		}
		[TestMethod]
		public void IsInRange_PassUpperLimit_ShouldReturnTrue()
		{
			var range = new BoundedRange<int>(0, BoundType.Open, 10, BoundType.Closed);

			bool inRange = range.IsValueInRange(10);

			Assert.IsTrue(inRange);
		}
	}
}
