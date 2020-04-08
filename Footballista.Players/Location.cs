using System.Globalization;

namespace Footballista.Players
{
	public class Location
	{
		public string City { get; }
		public string ZipCode { get; }
		public RegionInfo Country { get; }


		public Location(string city, string countryCode)
		{
			City = city;
			Country = new RegionInfo(countryCode);
		}
		public Location(string city, string zipCode, string countryCode)
		{
			City = city;
			ZipCode = zipCode;
			Country = new RegionInfo(countryCode);
		}
	}
}
