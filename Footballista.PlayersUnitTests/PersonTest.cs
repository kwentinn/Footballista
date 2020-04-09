using Footballista.Players;
using Itenso.TimePeriod;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Globalization;

namespace Footballista.PlayersUnitTests
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
				birthLocation: new Location("Montpellier", "FR"),
				nationalities: new RegionInfo("FR")
			);

			Assert.IsNotNull(someone);

		}
	}
}
