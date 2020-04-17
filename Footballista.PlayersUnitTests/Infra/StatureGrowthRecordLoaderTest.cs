using Footballista.Players.Infrastracture.Loaders;
using Footballista.Players.Infrastracture.Loaders.Growths;
using Footballista.Players.Infrastracture.Loaders.Growths.Records;
using Footballista.Players.Persons;
using Microsoft.Extensions.Hosting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;

namespace Footballista.PlayersUnitTests.Infra
{
	[TestClass]
	public class StatureGrowthRecordLoaderTest
	{
		[TestMethod]
		public void GetRecords_PassGenderMale_ShouldReturnRecordsForMale()
		{
			// arrange: create & setup mocks, create loader with mock
			Mock<IDataPathHelper> mockDataPathHelper = new Mock<IDataPathHelper>();
			mockDataPathHelper
				.Setup(env => env.GetFullPath(It.IsAny<string>(), It.IsAny<string>()))
				.Returns(() => @"C:\code\Footballista\Footballista\");

			StatureGrowthRecordLoader loader = new StatureGrowthRecordLoader(mockDataPathHelper.Object);

			// act
			List<GrowthRecord> data = loader.GetRecords(Gender.Male);

			// assert
			Assert.IsNotNull(data);
			Assert.AreEqual(19, data.Count);
		}
		[TestMethod]
		public void GetRecords_PassGenderFemale_ShouldReturnRecordsForFemale()
		{
			// arrange: create & setup mocks, create loader with mock
			Mock<IDataPathHelper> mockDataPathHelper = new Mock<IDataPathHelper>();
			mockDataPathHelper
				.Setup(env => env.GetFullPath(It.IsAny<string>(), It.IsAny<string>()))
				.Returns(() => @"C:\code\Footballista\Footballista\");

			StatureGrowthRecordLoader loader = new StatureGrowthRecordLoader(mockDataPathHelper.Object);

			// act
			var data = loader.GetRecords(Gender.Female);

			// assert
			Assert.IsNotNull(data);
		}
	}
}
