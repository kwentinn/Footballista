using Footballista.BuildingBlocks.Domain.ValueObjects;
using Footballista.Players.Builders.Generators;
using Footballista.Players.Persons;
using Footballista.Players.PlayerNames;

namespace Footballista.Players.Infrastracture.Generators
{
	public class PersonNameGenerator : IPersonNameGenerator
	{
		private readonly IFirstnameGenerator _firstnameGenerator;
		private readonly ILastnameGenerator _lastnameGenerator;

		public PersonNameGenerator
		(
			IFirstnameGenerator firstnameGenerator,
			ILastnameGenerator lastnameGenerator
		)
		{
			_firstnameGenerator = firstnameGenerator;
			_lastnameGenerator = lastnameGenerator;
		}

		public PersonName Generate(Gender gender, Country country)
		{
			Firstname firstname = _firstnameGenerator.Generate(gender, country);
			Lastname lastname = _lastnameGenerator.Generate(gender, country);

			return new PersonName(firstname, lastname);
		}
	}
}
