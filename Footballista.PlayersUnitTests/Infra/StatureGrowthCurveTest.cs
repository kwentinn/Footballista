using Footballista.Players.Infrastracture;
using Footballista.Players.Infrastracture.Records;
using Footballista.Players.Persons;
using Footballista.Units;
using Footballista.Units.Converters;
using Footballista.Units.Lengths;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;

namespace Footballista.PlayersUnitTests.Infra
{
	[TestClass]
	public class StatureGrowthCurveTest
	{
		[TestMethod]
		public void GetAll_PassSoUT_SI_ShouldReturnGrowthCurveWithValuesInMeters()
		{
			// arrange: create & setup mocks, create loader with mock
			var mock = new Mock<IStatureGrowthRecordLoader>();
			mock
				.Setup(m => m.GetRecords(It.IsAny<Gender>()))
				.Returns(() => new List<StatureGrowthRecord>
				{
					new StatureGrowthRecord
					{
						Age = 10,
						ThirdPercentile = 100,
						FifthPercentile = 105,
						TenthPercentile = 107,
						TwentyFifthPercentile = 110,
						FiftiethPercentile = 120,
						SeventyFifthPercentile = 125,
						NinetiethPercentile = 130,
						NinetyFifthPercentile = 135,
						NinetySeventhPercentile = 140,
						NinetyEigthPercentile = 150
					}
				});
			var mockConverter = new Mock<IConverter<Meter, Foot>>();
			mockConverter.Setup(m => m.Convert(It.IsAny<Meter>()))
				.Returns(new Foot(4.5));

			StatureGrowthCurveRepository repo = new StatureGrowthCurveRepository(mock.Object, mockConverter.Object);

			// act
			var data = repo.GetAll(SystemOfUnitsType.SI);

			// assert
			Assert.IsNotNull(data);
			Assert.AreEqual(20, data.Count);
		}


		[TestMethod]
		public void GetAll_PassSoUT_Imperial_ShouldReturnGrowthCurveWithValuesInFeet()
		{
			// arrange: create & setup mocks, create loader with mock
			var mock = new Mock<IStatureGrowthRecordLoader>();
			mock
				.Setup(m => m.GetRecords(It.IsAny<Gender>()))
				.Returns(() => new List<StatureGrowthRecord>
				{
					new StatureGrowthRecord
					{
						Age = 10,
						ThirdPercentile = 100,
						FifthPercentile = 105,
						TenthPercentile = 107,
						TwentyFifthPercentile = 110,
						FiftiethPercentile = 120,
						SeventyFifthPercentile = 125,
						NinetiethPercentile = 130,
						NinetyFifthPercentile = 135,
						NinetySeventhPercentile = 140,
						NinetyEigthPercentile = 150
					}
				});
			var mockConverter = new Mock<IConverter<Meter, Foot>>();
			mockConverter.Setup(m => m.Convert(It.IsAny<Meter>()))
				.Returns(new Foot(4.5));

			StatureGrowthCurveRepository repo = new StatureGrowthCurveRepository(mock.Object, mockConverter.Object);

			// act
			var data = repo.GetAll(SystemOfUnitsType.Imperial);

			// assert
			Assert.IsNotNull(data);
			Assert.AreEqual(20, data.Count);
		}
	}
}
