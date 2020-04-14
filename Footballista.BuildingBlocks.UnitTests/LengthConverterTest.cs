using Footballista.Units.Converters;
using Footballista.Units.Lengths;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Footballista.BuildingBlocks.UnitTests.PlayersUnitTests
{
	[TestClass]
	public class LengthConverterTest
	{
		private readonly LengthConverter _converter = new LengthConverter();

		[TestMethod]
		public void New_ShouldReturnNewInstance()
		{
			Assert.IsNotNull(_converter);
		}

		[TestMethod]
		public void Convert_PassOneMeter_ShouldReturn3Feet2808()
		{
			Foot result = _converter.Convert(new Meter(1));

			Assert.IsNotNull(result);
			Assert.AreNotEqual(0, result.Value);
			Assert.IsTrue(Math.Abs(3.2808 - result.Value) < 0.01);
		}

		[TestMethod]
		public void ConvertBack_PassOneFoot_ShouldReturn0Meter3048()
		{
			Meter result = _converter.ConvertBack(new Foot(1));

			Assert.IsNotNull(result);
			Assert.AreNotEqual(0, result.Value);
			Assert.IsTrue(Math.Abs(0.3048 - result.Value) < 0.01);
		}
		[TestMethod]
		public void ConvertBack_Pass2_5Foot_ShouldReturn0_762Meter()
		{
			Meter result = _converter.ConvertBack(new Foot(2.5));

			Assert.IsNotNull(result);
			Assert.AreNotEqual(0, result.Value);
			Assert.IsTrue(Math.Abs(0.762 - result.Value) < 0.01);
		}
	}
}
