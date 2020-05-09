using Footballista.BuildingBlocks.Domain.ValueObjects;
using Footballista.Players.Builders.Generators;
using Footballista.Players.Builders.Randomisers;
using Footballista.Players.Infrastracture.Loaders.Cities;
using Footballista.Players.Infrastracture.Loaders.Cities.Records;
using System.Collections.Generic;

namespace Footballista.Players.Infrastracture.Generators
{
	public class BirthLocationGenerator : IBirthLocationGenerator
	{
		private readonly IWorldCitiesLoader _worldCitiesLoader;
		private readonly IListRandomiser _listRandomiser;

		public BirthLocationGenerator
		(
			IWorldCitiesLoader worldCitiesLoader, 
			IListRandomiser listRandomiser
		)
		{
			_worldCitiesLoader = worldCitiesLoader;
			_listRandomiser = listRandomiser;
		}

		public Location Generate(Country country)
		{
			List<WorldCityRecord> cities = _worldCitiesLoader.GetRecords().Value;

			WorldCityRecord city = _listRandomiser.GetRandomisedItem(cities, record => record.CountryCodeIso2 == country.RegionInfo.TwoLetterISORegionName);

			return new Location(new City(city.City), country);
		}
	}
}
