using Footballista.BuildingBlocks.Domain;
using Footballista.BuildingBlocks.Domain.ValueObjects;
using Itenso.TimePeriod;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Footballista.Players.Persons
{
	public class Person : Entity
	{
		public PersonId Id { get; }
		public string Firstname { get; }
		public string Lastname { get; }
		public Gender Gender { get; }
		public Birth BirthInfo { get; }

		private List<Country> _nationalities = new List<Country>();
		public ReadOnlyCollection<Country> Nationalities => _nationalities.AsReadOnly();

		internal Person
		(
			PersonId id,
			string firstname,
			string lastname,
			Gender gender,
			Date dob,
			Location birthLocation,
			params Country[] nationalities
		)
		{
			CheckRule(new BusinessRules.PersonCanHaveMultipleNationalitiesRule(nationalities));

			Id = id;
			Firstname = firstname;
			Lastname = lastname;
			Gender = gender;
			BirthInfo = new Birth(dob, birthLocation);
			_nationalities.AddRange(nationalities);
		}

		internal Person(string firstname, string lastname, Gender gender, Date dob, Location birthLocation, params Country[] nationalities)
			: this(PersonId.CreateNew(), firstname, lastname, gender, dob, birthLocation, nationalities) { }

		public static Person CreateNew
		(
			string firstname,
			string lastname,
			Gender gender,
			Date dob,
			Location birthLocation,
			params Country[] nationalities
		)
		{
			return new Person(firstname, lastname, gender, dob, birthLocation, nationalities);
		}
	}
}
