using Itenso.TimePeriod;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;

namespace Footballista.Players
{
	public class Person
	{
		public PersonId Id { get; }
		public string Firstname { get; }
		public string Lastname { get; }
		public Gender Gender { get; }
		public Date DateOfBirth { get; }
		public Location BirthLocation { get; }

		private List<RegionInfo> _nationalities = new List<RegionInfo>();
		public ReadOnlyCollection<RegionInfo> Nationalities => _nationalities.AsReadOnly();

		internal Person
		(
			PersonId id,
			string firstname,
			string lastname, 
			Gender gender,
			Date dob,
			Location birthLocation,
			params RegionInfo[] nationalities
		)
		{
			Id = id;
			Firstname = firstname;
			Lastname = lastname;
			Gender = gender;
			DateOfBirth = dob;
			BirthLocation = birthLocation;
			_nationalities.AddRange(nationalities);
		}

		internal Person(string firstname, string lastname, Gender gender, Date dob, Location birthLocation, params RegionInfo[] nationalities)
			: this(PersonId.CreateNew(), firstname, lastname, gender, dob, birthLocation, nationalities) { }

		public static Person CreateNew
		(
			string firstname,
			string lastname,
			Gender gender,
			Date dob,
			Location birthLocation,
			params RegionInfo[] nationalities
		)
		{
			return new Person(firstname, lastname, gender, dob, birthLocation, nationalities);
		}
	}
}
