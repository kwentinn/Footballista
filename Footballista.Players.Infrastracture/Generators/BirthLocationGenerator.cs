using Footballista.BuildingBlocks.Domain.ValueObjects;
using Footballista.Players.Builders.Generators;
using Footballista.Players.Builders.Randomisers;
using Footballista.Players.Infrastracture.Loaders.Cities;
using Footballista.Players.Infrastracture.Loaders.Cities.Records;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Footballista.Players.Infrastracture.Generators
{
	public class BirthLocationGenerator : IBirthLocationGenerator
	{
		private readonly IWorldCitiesLoader _worldCitiesLoader;
		private readonly IListRandomiser _listRandomiser;
		
		private Random _random = new Random();

		//private List<Country> _countries = new List<Country>
		//{
		//	Country.China,
		//	Country.CzechRepublic,
		//	Country.Denmark,
		//	Country.Spain,
		//	Country.France,
		//	Country.England,
		//	Country.NorthernIreland,
		//	Country.Ireland,
		//	Country.Greece,
		//	Country.India,
		//	Country.Italy,
		//	Country.Korea,
		//	Country.Netherlands,
		//	Country.Poland,
		//	Country.Portugal,
		//	Country.Russia,
		//	Country.USA
		//};

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
			List<WorldCityRecord> cities = _worldCitiesLoader.GetRecords();
			if (!cities.Any()) throw new ApplicationException("No cities were loaded");

			WorldCityRecord city = _listRandomiser.GetRandomisedItem(cities, record => record.CountryCodeIso2 == country.RegionInfo.TwoLetterISORegionName);

			return new Location(new City(city.City), city.CountryCodeIso2);
		}
	}
}
