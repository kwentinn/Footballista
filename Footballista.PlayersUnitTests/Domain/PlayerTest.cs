using Footballista.BuildingBlocks.Domain.ValueObjects;
using Footballista.Players.Persons;
using Footballista.Players.PlayerNames;
using Itenso.TimePeriod;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Footballista.PlayersUnitTests.Domain
{
	[TestClass]
	public class PlayerTest
	{
		[TestMethod]
		public void MyTestMethod()
		{
			var p = Person.CreateNew
			(
				new Firstname("José"), new Lastname("Pelé"), 
				Gender.Male, 
				new Date(2000, 1, 1), 
				new Location(new City("Carnon"), "FR"),
				new Country("FR")
			);
		}
	}
}
