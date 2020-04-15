using Footballista.Players.Infrastracture;
using Footballista.Players.Infrastracture.Loaders.Growths;
using Footballista.Players.Infrastracture.Loaders.Growths.Records;
using Footballista.Players.Persons;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;

namespace Footballista.PlayersUnitTests.Infra
{
	[TestClass]
	public class PercentileGrowthSetRepositoryTest
	{
		[TestMethod]
		public void MyTestMethod()
		{
			var statureMock = new Mock<IStatureGrowthRecordLoader>();
			statureMock
				.Setup(m => m.GetRecords(It.IsAny<Gender>()))
				.Returns(() => new List<GrowthRecord>
				{
					new GrowthRecord
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

			var weightMock = new Mock<IWeightGrowthRecordLoader>();
			weightMock
				.Setup(m => m.GetRecords(It.IsAny<Gender>()))
				.Returns(() => new List<GrowthRecord>
				{
					new GrowthRecord
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

			var repo = new PercentileGrowthSetRepository(statureMock.Object, weightMock.Object);

			var data = repo.GetMalePercentileGrowthSet();
		}
	}
}
