using Footballista.Players.Units.Length;
using Footballista.Players.Units.Mass;
using Itenso.TimePeriod;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Footballista.Players
{
	public class Person
	{
		public Guid Id { get; }
		public string Firstname { get; }
		public string Lastname { get; }
		public Date DateOfBirth { get; }
		public Location BirthLocation { get; }

		private List<Nationality> _nationalities = new List<Nationality>();
		public ReadOnlyCollection<Nationality> Nationalities => _nationalities.AsReadOnly();

		internal Person
		(
			Guid id, 
			string firstname, 
			string lastname, 
			Date dob, 
			Location birthLocation, 
			params Nationality[] nationalities
		)
		{
			Id = id;
			Firstname = firstname;
			Lastname = lastname;
			DateOfBirth = dob;
			BirthLocation = birthLocation;
			_nationalities.AddRange(nationalities);
		}
		internal Person(string firstname, string lastname, Date dob, Location birthLocation, params Nationality[] nationalities)
			: this(Guid.NewGuid(), firstname, lastname, dob, birthLocation, nationalities) { }

		public static Person CreatePerson
		(
			string firstname, 
			string lastname, 
			Date dob, 
			Location location, 
			params Nationality[] nationalities
		)
		=> new Person(firstname, lastname, dob, location, nationalities);
	}

	public class Nationality
	{
		public string Name { get; }
		public Country Country { get; }
	}

	public class Country
	{
		public string Name { get; }
		public string IsoCode { get; }
	}

	public class Location
	{
		public string City { get; }
		public string ZipCode { get; }
		public string Country { get; }
	}

	public class PhysicalFeature
	{
		public LengthUnit Height { get; }
		public MassUnit Weight { get; }
		public Date PointInTime { get; }
	}

	public interface IEvolution { }


	public class AgeInYear
	{
		public int Year { get; set; }
	}

	public class Growth 
	{
		public int Age { get; set; }
		public MassUnit Mass { get; set; }
		public LengthUnit Length { get; set; }
	}

	public class NormalGrowth
	{
		private readonly List<Growth> _growthItems = new List<Growth>();
		public ReadOnlyCollection<Growth> GrowthItems => _growthItems.AsReadOnly();
	}
}
