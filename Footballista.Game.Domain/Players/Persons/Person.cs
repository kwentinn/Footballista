using Footballista.BuildingBlocks.Domain;
using Footballista.BuildingBlocks.Domain.ValueObjects;
using Footballista.Game.Domain.Players.Persons.Rules;
using Footballista.Game.Domain.Players.PlayerNames;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Footballista.Game.Domain.Players.Persons
{
    public class Person : Entity
	{
		public PersonId Id { get; }
		public PersonName Name { get; }
		public Gender Gender { get; }
		public BirthInfo BirthInfo { get; }

        private readonly List<Country> _nationalities = new List<Country>();
		public ReadOnlyCollection<Country> Nationalities => this._nationalities.AsReadOnly();

		protected Person(PersonId id, PersonName name, Gender gender, BirthInfo birthInfo, params Country[] nationalities)
		{
            CheckRule(new PersonMustHaveTwoNationalitiesMaximum(nationalities));

            this.Id = id;
            this.Name = name;
            this.Gender = gender;
            this.BirthInfo = birthInfo;

            this._nationalities.AddRange(nationalities);
		}

		public static Person CreateNew(PersonName name, Gender gender, BirthInfo birthInfo, params Country[] nationalities)
		{
			return new Person(PersonId.CreateNew(), name, gender, birthInfo, nationalities);
		}
	}
}
