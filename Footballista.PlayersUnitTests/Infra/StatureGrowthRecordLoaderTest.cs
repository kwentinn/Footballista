using Footballista.BuildingBlocks.Domain;
using Footballista.Players.Domain.Persons;
using Footballista.Players.Infrastracture.Loaders;
using Footballista.Players.Infrastracture.Loaders.Growths;
using Footballista.Players.Infrastracture.Loaders.Growths.Records;
using Microsoft.Extensions.Hosting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.IO;

namespace Footballista.PlayersUnitTests.Infra
{
	[TestClass]
	public class StatureGrowthRecordLoaderTest
	{
		[TestMethod]
		public void GetRecords_PassGenderMale_ShouldReturnRecordsForMale()
		{
			string dataPath = Directory.GetCurrentDirectory() + @"\..\..\..\..\data\growth-charts\Stature-for-age-Male-2-to-20-years.csv";

			// arrange: create & setup mocks, create loader with mock
			Mock<IDataPathHelper> mockDataPathHelper = new Mock<IDataPathHelper>();
			mockDataPathHelper
				.Setup(env => env.GetFullPath(It.IsAny<string>(), It.IsAny<string>()))
				.Returns(() => dataPath);

			StatureGrowthRecordLoader loader = new StatureGrowthRecordLoader(mockDataPathHelper.Object);

			// act
			Maybe<List<GrowthRecord>> maybeData = loader.GetRecords(Gender.Male);

			// assert
			Assert.IsTrue(maybeData.HasValue);
			Assert.AreEqual(19, maybeData.Value.Count);
		}
		[TestMethod]
		public void GetRecords_PassGenderFemale_ShouldReturnRecordsForFemale()
		{
			string dataPath = Directory.GetCurrentDirectory() + @"\..\..\..\..\data\growth-charts\Stature-for-age-Female-2-to-20-years.csv";
			
			// arrange: create & setup mocks, create loader with mock
			Mock<IDataPathHelper> mockDataPathHelper = new Mock<IDataPathHelper>();
			mockDataPathHelper
				.Setup(env => env.GetFullPath(It.IsAny<string>(), It.IsAny<string>()))
				.Returns(() => dataPath);

			StatureGrowthRecordLoader loader = new StatureGrowthRecordLoader(mockDataPathHelper.Object);

			// act
			Maybe<List<GrowthRecord>> data = loader.GetRecords(Gender.Female);

			// assert
			Assert.IsTrue(data.HasValue);
		}
	}
}
