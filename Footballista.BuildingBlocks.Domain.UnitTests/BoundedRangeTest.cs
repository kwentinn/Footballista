using FluentAssertions;
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
				var range = new BoundedRange<int>(
				 new ExcludingBound<int>(0), new IncludingBound<int>(0));
			});
		}
		[TestMethod]
		public void New_PassZeroAsMinAndMinusOneAsMax_ShouldThrowBusinessRuleValidationException()
		{
			Assert.ThrowsException<BusinessRuleValidationException>(() =>
			{
				var range = new BoundedRange<int>(
					new ExcludingBound<int>(0), new IncludingBound<int>(-1));
			});
		}
		[TestMethod]
		public void New_Pass0AsLowerAnd10AsUpper_ShouldReturnNewInstance()
		{
			var range = new BoundedRange<int>(
				new ExcludingBound<int>(0),
				new IncludingBound<int>(10));

			Assert.IsNotNull(range);
		}
		[TestMethod]
		public void New_Pass0AsLowerAnd10AsUpper_ShouldReturnNewInstance2()
		{
			var range = new BoundedRange<int>(new ExcludingBound<int>(0), new IncludingBound<int>(10));

			Assert.IsNotNull(range);
		}
		[TestMethod]
		public void IsInRange_()
		{
			var range = new BoundedRange<int>(new ExcludingBound<int>(0), new IncludingBound<int>(10));

			bool inRange = range.IsValueInRange(5);

			inRange.Should().BeTrue();
		}
		[TestMethod]
		public void IsInRange_PassLowerLimit_ShouldReturnFalse()
		{
			var range = new BoundedRange<int>(new ExcludingBound<int>(0), new IncludingBound<int>(10));

			bool inRange = range.IsValueInRange(0);

			Assert.IsFalse(inRange);
		}
		[TestMethod]
		public void IsInRange_PassUpperLimit_ShouldReturnTrue()
		{
			var range = new BoundedRange<int>(new ExcludingBound<int>(0), new IncludingBound<int>(10));

			bool inRange = range.IsValueInRange(10);

			Assert.IsTrue(inRange);
		}
	}
}
