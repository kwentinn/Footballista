using Footballista.BuildingBlocks.Domain.ValueObjects;
using Footballista.Players.Builders.Generators;
using Footballista.Game.Domain.Players.Persons;
using Footballista.Game.Domain.Players.PlayerNames;
using System.Threading.Tasks;

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
		public async Task<PersonName> GenerateAsync(Gender gender, Country country)
		{
			Firstname firstname = await _firstnameGenerator.GenerateAsync(gender, country);
			Lastname lastname = await _lastnameGenerator.GenerateAsync(gender, country);

			return new PersonName(firstname, lastname);
		}
	}
}
