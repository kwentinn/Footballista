using FluentAssertions;
using Footballista.Players.Domain.Positions;
using Footballista.Players.Features.Attributes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Footballista.PlayersUnitTests.Domain
{

	[TestClass]
    public class AttributesTest
    {
        [TestMethod]
        public void MyTestMethod()
        {
            BehaviouralAttributes ba = new BehaviouralAttributes(0.8, 0.5, 0.25);

            var rating = ba.Rating;

            bool match = ba.IsMatchForPosition(PlayerPosition.CentreBack);

            match.Should().BeTrue();

        }
    }
}
