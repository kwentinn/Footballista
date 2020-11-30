namespace Footballista.Players.Infrastracture.Loaders.Cities.Records
{
	public class WorldCityRecord
	{
		public string City { get; set; }
		public string CityAscii { get; set; }
		public double Latitude { get; set; }
		public double Longitude { get; set; }
		public string Country { get; set; }
		public string CountryCodeIso2 { get; set; }
		public string CountryCodeIso3 { get; set; }
		public string AdminName { get; set; }
		public string Capital { get; set; }
		public double? Population { get; set; }
		public long Id { get; set; }
	}
}
