using CsvHelper.Configuration;
using Footballista.Players.Infrastracture.Loaders.Cities.Records;

namespace Footballista.Players.Infrastracture.Loaders.Cities.ClassMaps
{
	public class WorldCityRecordClassMap : ClassMap<WorldCityRecord>
	{
		public WorldCityRecordClassMap()
		{
			Map(m => m.City).Name("city");
			Map(m => m.CityAscii).Name("city_ascii");
			Map(m => m.Latitude).Name("lat");
			Map(m => m.Longitude).Name("lng");
			Map(m => m.Country).Name("country");
			Map(m => m.CountryCodeIso2).Name("iso2");
			Map(m => m.CountryCodeIso3).Name("iso3");
			Map(m => m.AdminName).Name("admin_name");
			Map(m => m.Capital).Name("capital");
			Map(m => m.Population).Name("population");
			Map(m => m.Id).Name("id");
		}
	}
}
