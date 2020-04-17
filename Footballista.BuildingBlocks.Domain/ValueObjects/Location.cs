namespace Footballista.BuildingBlocks.Domain.ValueObjects
{
	public class Location
	{
		public City City { get; }
		public Country Country { get; }

		public Location(City city, string countryCode)
		{
			City = city;
			Country = new Country(countryCode);
		}
	}
}
