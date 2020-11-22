using Footballista.BuildingBlocks.Domain;
using Footballista.BuildingBlocks.Domain.ValueObjects;
using System.Linq;

namespace Footballista.Players.Persons.BusinessRules
{
	public class PersonMustHaveTwoNationalitiesMaximum : IBusinessRule
	{
		private readonly Country[] _countries;

		public string Message => "A person cannot have more than two nationalities.";

		public PersonMustHaveTwoNationalitiesMaximum(Country[] countries)
		{
			_countries = countries;
		}

		public bool IsBroken() => _countries.Distinct().Count() > 2;
	}
}
