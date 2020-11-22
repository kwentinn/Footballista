using Footballista.BuildingBlocks.Domain;
using Footballista.BuildingBlocks.Domain.ValueObjects;
using Footballista.Players.PlayerNames;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Footballista.Players.Persons
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
            CheckRule(new BusinessRules.PersonMustHaveTwoNationalitiesMaximum(nationalities));

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
