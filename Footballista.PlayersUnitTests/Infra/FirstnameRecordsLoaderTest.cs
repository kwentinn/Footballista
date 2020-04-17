using Footballista.Players.Infrastracture.Loaders;
using Footballista.Players.Infrastracture.Loaders.Firstnames;
using Footballista.Players.Infrastracture.Loaders.Firstnames.Records;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.IO;

namespace Footballista.PlayersUnitTests.Infra
{
	[TestClass]
	public class FirstnameRecordsLoaderTest
	{
		[TestMethod]
		public void GetRecords()
		{
			string currentDir = Directory.GetCurrentDirectory() + @"\..\..\..\..\";

			// arrange: create & setup mocks, create loader with mock
			Mock<IDataPathHelper> mockDataPathHelper = new Mock<IDataPathHelper>();
			mockDataPathHelper
				.Setup(env => env.GetFullPath(It.IsAny<string>(), It.IsAny<string>()))
				.Returns(() => currentDir);

			var loader = new FirstnameRecordsLoader(mockDataPathHelper.Object);

			List<FirstnameRecord> records = loader.GetRecords();

			Assert.IsNotNull(records);
		}
	}
}
