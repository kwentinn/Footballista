using Footballista.BuildingBlocks.Domain.ValueObjects.Units.Length;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Footballista.PlayersUnitTests
{
	[TestClass]
	public class MeterTest
	{
		[TestMethod]
		public void New_DefaultConstructor_ShouldReturnNewInstance()
		{
			var meter = new Meter();

			Assert.IsNotNull(meter);
		}

		[TestMethod]
		public void New_ConstructorWithOneParam_ShouldReturnNewInstance()
		{
			var meter = new Meter(100);

			Assert.IsNotNull(meter);
			Assert.AreEqual(100, meter.Value);
		}
	}
}
