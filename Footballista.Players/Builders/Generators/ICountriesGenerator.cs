using Footballista.BuildingBlocks.Domain.ValueObjects;
using Footballista.Players.Builders.Randomisers;
using System;
using System.Collections.Generic;

namespace Footballista.Players.Builders.Generators
{
	public interface ICountriesGenerator
	{
		Country[] Generate();
	}
	public class CountriesGenerator : ICountriesGenerator
	{
		private Random _random = new Random();

		private readonly IListRandomiser _listRandomiser;

		private List<Country> _countries = new List<Country>
		{
			Country.China,
			Country.CzechRepublic,
			Country.Denmark,
			Country.Spain,
			Country.France,
			Country.England,
			Country.NorthernIreland,
			Country.Scotland,
			Country.Ireland,
			Country.Greece,
			Country.India,
			Country.Italy,
			Country.Korea,
			Country.Netherlands,
			Country.Poland,
			Country.Portugal,
			Country.Russia,
			Country.USA
		};

		public CountriesGenerator(IListRandomiser listRandomiser)
		{
			_listRandomiser = listRandomiser;
		}

		public Country[] Generate()
		{
			return _listRandomiser.GetRandomisedItems(_countries, _random.Next(1, 3));
		}
	}
}
