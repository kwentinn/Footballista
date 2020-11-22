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
				name: new PersonName(new Firstname("Michael"), new Lastname("Monroe")),
				gender: Gender.Male,
				birthInfo: new BirthInfo(new Date(1990, 5, 11), new Location(new City("Montpellier"), Country.France)),
				nationalities: Country.France
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
					new PersonName(new Firstname("Michael"), new Lastname("Monroe")),
					Gender.Male,
					new BirthInfo(1990, 5, 11, "Montpellier", Country.France),
					Country.France, Country.Germany, Country.Italy
				);
			});
		}
	}
}
