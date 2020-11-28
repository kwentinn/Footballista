using Footballista.BuildingBlocks.Domain;
using Footballista.BuildingBlocks.Domain.ValueObjects;
using Footballista.Players.Domain.Persons.Rules;
using Footballista.Players.Domain.PlayerNames;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Footballista.Players.Domain.Persons
{
	public class Person : Entity
	{
		public PersonId Id { get; }
		public PersonName Name { get; }
		public Gender Gender { get; }
		public BirthInfo BirthInfo { get; }

		private readonly List<Country> _nationalities = new List<Country>();
		public ReadOnlyCollection<Country> Nationalities => _nationalities.AsReadOnly();

		protected Person(PersonId id, PersonName name, Gender gender, BirthInfo birthInfo, params Country[] nationalities)
		{
			CheckRule(new PersonMustHaveTwoNationalitiesMaximum(nationalities));

			Id = id;
			Name = name;
			Gender = gender;
			BirthInfo = birthInfo;

			_nationalities.AddRange(nationalities);
		}

		public static Person CreateNew(PersonName name, Gender gender, BirthInfo birthInfo, params Country[] nationalities)
		{
			return new Person(PersonId.CreateNew(), name, gender, birthInfo, nationalities);
		}
	}
}
