using Itenso.TimePeriod;

namespace Footballista.Players
{
	public class Person
	{
		public string Firstname { get; }
		public string Lastname { get; }
		public Date DateOfBirth { get; }
		public Location BirthLocation { get; }
	}

	public class Location
	{
		public string City { get; }
		public string ZipCode { get; }
		public string Country { get; }
	}

	public class PhysicalFeature
	{
		//public Height Height { get; }
	}

}
