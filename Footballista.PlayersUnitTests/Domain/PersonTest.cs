using Footballista.BuildingBlocks.Domain;
using Footballista.BuildingBlocks.Domain.ValueObjects;
using Footballista.Players.Persons;
using Footballista.Players.PlayerNames;
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
				firstname: new Firstname("Michael"),
				lastname: new Lastname("Monroe"),
				gender: Gender.Male,
				dob: new Date(1990, 5, 11),
				birthLocation: new Location(new City("Montpellier"), "FR"),
				nationalities: new Country("FR")
			);

			Assert.IsNotNull(someone);

		}
		[TestMethod]
		public void CreateNewPerson_Pass3Nationalities_ShouldThrowBusinessRuleValidationException()
		{

			Assert.ThrowsException<BusinessRuleValidationException>(() =>
			{
				Person someone = Person.CreateNew
				(
					new Firstname("Michael"),
					new Lastname("Monroe"),
					Gender.Male,
					new Date(1990, 5, 11),
					new Location(new City("Montpellier"), "FR"),
					new Country("FR"), new Country("de"), new Country("it")
				);
			});
		}
	}
}
