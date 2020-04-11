namespace Footballista.BuildingBlocks.Domain.ValueObjects
{
	public class Location
	{
		public City City { get; }
		public ZipCode ZipCode { get; }
		public Country Country { get; }


		public Location(City city, string countryCode)
		{
			City = city;
			Country = new Country(countryCode);
		}
		public Location(City city, ZipCode zipCode, string countryCode)
		{
			City = city;
			ZipCode = zipCode;
			Country = new Country(countryCode);
		}
	}
}
