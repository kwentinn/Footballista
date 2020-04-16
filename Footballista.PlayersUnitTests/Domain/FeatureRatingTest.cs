using Footballista.BuildingBlocks.Domain;
using Footballista.Players.Features;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Footballista.PlayersUnitTests.Domain
{
	[TestClass]
	public class FeatureRatingTest
	{
		[TestMethod]
		public void New_PassZero_ShouldThrowBusinessRuleValidationException()
		{
			Assert.ThrowsException<BusinessRuleValidationException>(() => new FeatureRating(-10d));
		}
	}
}
