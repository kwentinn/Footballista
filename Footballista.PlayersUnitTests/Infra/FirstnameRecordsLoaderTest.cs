using Footballista.Players.Infrastracture.Loaders.Firstnames;
using Footballista.Players.Infrastracture.Loaders.Firstnames.Records;
using Microsoft.Extensions.Hosting;
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
			Mock<IHostEnvironment> hostEnvMock = new Mock<IHostEnvironment>();
			hostEnvMock
				.Setup(env => env.ContentRootPath)
				.Returns(() => currentDir);

			var loader = new FirstnameRecordsLoader(hostEnvMock.Object);

			List<FirstnameRecord> records = loader.GetRecords();

			Assert.IsNotNull(records);
		}
	}
}
