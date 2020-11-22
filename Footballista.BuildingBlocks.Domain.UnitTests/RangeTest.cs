using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Footballista.BuildingBlocks.Domain.UnitTests
{
	[TestClass]
	public class RangeTest
	{
		[TestMethod]
		public void New_PassZeroAsMinAndMaxValues_ShouldThrowBusinessRuleValidationException()
		{
			Assert.ThrowsException<BusinessRuleValidationException>(() =>
			{
				var range = new Range<int>(0, 0);
			});
		}
		[TestMethod]
		public void New_PassZeroAsMinAndMinusOneAsMax_ShouldThrowBusinessRuleValidationException()
		{
			Assert.ThrowsException<BusinessRuleValidationException>(() =>
			{
				var range = new Range<int>(0, -1);
			});
		}
		[TestMethod]
		public void New_PassZeroAsMinAndOneAsMax_ShouldReturnNewInstance()
		{
			var range = new Range<int>(0, 1);

			Assert.IsNotNull(range);
		}
	}
}
