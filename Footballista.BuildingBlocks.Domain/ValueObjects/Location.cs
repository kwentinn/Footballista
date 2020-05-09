using System.Diagnostics;

namespace Footballista.BuildingBlocks.Domain.ValueObjects
{
	[DebuggerDisplay("{City}, {Country}")]
	public class Location
	{
		public City City { get; }
		public Country Country { get; }

		public Location(City city, Country country)
		{
			City = city;
			Country = country;
		}
	}
}
