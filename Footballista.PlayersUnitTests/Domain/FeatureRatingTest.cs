using Footballista.BuildingBlocks.Domain;
using Footballista.Players.Domain.Features;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Footballista.PlayersUnitTests.Domain
{
	[TestClass]
	public class FeatureRatingTest
	{
		[TestMethod]
		public void New_PassZero_ShouldThrowBusinessRuleValidationException()
		{
			Assert.ThrowsException<BusinessRuleValidationException>(() => new Rating(-10d));
		}
	}
}
