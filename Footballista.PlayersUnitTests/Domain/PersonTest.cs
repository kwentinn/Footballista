using Footballista.BuildingBlocks.Domain.ValueObjects;
using Footballista.Players.Persons;
using Itenso.TimePeriod;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Globalization;

namespace Footballista.PlayersUnitTests.Domain
{
	[TestClass]
	public class PersonTest
	{
		[TestMethod]
		public void CreateNewPerson()
		{
			Person someone = Person.CreateNew
			(
				firstname: "Michael",
				lastname: "Monroe",
				gender: Gender.Male,
				dob: new Date(1990, 5, 11),
				birthLocation: new Location(new City("Montpellier"), "FR"),
				nationalities: new Country("FR")
			);

			Assert.IsNotNull(someone);

		}
	}
}
