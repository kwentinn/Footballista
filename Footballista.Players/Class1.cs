using Footballista.Players.Units.Length;
using Footballista.Players.Units.Mass;
using Itenso.TimePeriod;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Footballista.Players
{
	public class Person
	{
		public string Firstname { get; }
		public string Lastname { get; }
		public Date DateOfBirth { get; }
		public Location BirthLocation { get; }

		private List<Nationality> _nationalities = new List<Nationality>();
		public ReadOnlyCollection<Nationality> Nationalities => _nationalities.AsReadOnly();
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

}
