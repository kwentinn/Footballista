using Microsoft.VisualStudio.TestTools.UnitTesting;
using Footballista.Wasm.Shared.Extensions;
using Itenso.TimePeriod;

namespace Footballista.Wasm.Shared.UnitTests
{
	[TestClass]
	public class DateExtensionsUnitTests
	{
		[TestMethod]
		public void AddDays_Pass0_ShouldReturnSameDate()
		{
			Date d = new Date(2020);

			var result = d.AddDays(0);

			Assert.IsNotNull(result);
			Assert.AreEqual(d, result);
		}

		[TestMethod]
		public void AddDays_To_2020_01_01_Pass1_ShouldReturnNextDay()
		{
			Date d = new Date(2020);

			var result = d.AddDays(1);

			Assert.IsNotNull(result);
			Assert.AreNotEqual(d, result);
			Assert.AreEqual(new Date(2020, 1, 2), result);
		}

		[TestMethod]
		public void LastDayOfMonth_From_Date_2020_01_01_ShouldReturn_Date_2020_01_31()
		{
			var d = new Date(2020);

			var result = d.LastDayOfMonth();

			Assert.IsNotNull(result);
			Assert.AreNotEqual(d, result);
			Assert.AreEqual(new Date(2020, 1, 31), result);
		}

		[TestMethod]
		public void LastDayOfMonth_From_Date_2020_12_01_ShouldReturn_Date_2020_12_31()
		{
			var d = new Date(2020, 12);

			var result = d.LastDayOfMonth();

			Assert.IsNotNull(result);
			Assert.AreNotEqual(d, result);
			Assert.AreEqual(new Date(2020, 12, 31), result);
		}
	}
}
