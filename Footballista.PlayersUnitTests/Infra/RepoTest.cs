using Footballista.BuildingBlocks.Domain.ValueObjects.Units;
using Footballista.Players.Infrastracture;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace Footballista.PlayersUnitTests.Infra
{
	[TestClass]
	public class StatureGrowthCurveRepositoryTest
	{
		[TestMethod]
		public async Task New()
		{
			var repo = new StatureGrowthCurveRepository();

			var data = await repo.GetAllAsync(SystemOfUnitsType.SI);

			Assert.IsNotNull(data);
		}
	}
}
