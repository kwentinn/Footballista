using Footballista.BuildingBlocks.Domain.ValueObjects.Units.Mass;
using Footballista.BuildingBlocks.ValueObjects.Units.Converters;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Footballista.PlayersUnitTests
{
	[TestClass]
	public class MassConverterTest
	{
		private readonly MassConverter _converter = new MassConverter();

		[TestMethod]
		public void New()
		{
			Assert.IsNotNull(_converter);
		}

		[TestMethod]
		public void Convert_1kg_ShouldReturn2_204623lb()
		{
			Pound result = _converter.Convert(new Kilogram(1));

			Assert.IsNotNull(result);
			Assert.IsTrue(Math.Abs(2.204623 - result.Value) < 0.01);
		}

		[TestMethod]
		public void ConvertBack_1lb_ShouldReturn_kg()
		{
			Kilogram result = _converter.ConvertBack(new Pound(1));

			Assert.IsNotNull(result);
			Assert.IsTrue(Math.Abs(0.4535923 - result.Value) < 0.01);
		}

		[TestMethod]
		public void ConvertBack_220lb_ShouldReturn_99kg()
		{
			Kilogram result = _converter.ConvertBack(new Pound(220));

			Assert.IsNotNull(result);
			Assert.IsTrue(Math.Abs(99.7903 - result.Value) < 0.01);
		}
	}
}
