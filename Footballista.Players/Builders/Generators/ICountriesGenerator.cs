using Footballista.BuildingBlocks.Domain;
using Footballista.BuildingBlocks.Domain.ValueObjects;
using Footballista.Players.Builders.Randomisers;
using System.Collections.Generic;

namespace Footballista.Players.Builders.Generators
{
	public interface ICountriesGenerator
	{
		Maybe<Country[]> Generate();
	}
	public class CountriesGenerator : ICountriesGenerator
	{
		private readonly IListRandomiser _listRandomiser;
		private readonly IRandomiser<int> _intRandomiser;

		private List<Country> _countries = new List<Country>
		{
			Country.China,
			Country.Japan,
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

		public Maybe<Country[]> Generate()
		{
			return Maybe.Some(_listRandomiser.GetRandomisedItems(
				list: _countries,
				nbOfItemsToReturn: _intRandomiser.Randomise(1, 3)));
		}
	}
}
