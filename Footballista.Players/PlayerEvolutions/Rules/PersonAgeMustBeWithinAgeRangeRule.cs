using Footballista.BuildingBlocks.Domain;

namespace Footballista.Players.PlayerEvolutions.Rules
{
	public class PersonAgeMustBeWithinAgeRangeRule : IBusinessRule
	{
		private readonly PersonAge _age;
		private readonly Range<PersonAge> _validRange;

		public string Message => "Person age must be within age range";

		public PersonAgeMustBeWithinAgeRangeRule(PersonAge age, Range<PersonAge> validRange)
		{
			_age = age;
			_validRange = validRange;
		}

		public bool IsBroken() => !_validRange.IsValueInRange(_age);
	}
}
