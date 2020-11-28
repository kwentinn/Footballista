using Footballista.BuildingBlocks.Domain;
using Footballista.BuildingBlocks.Domain.ValueObjects;
using Footballista.Players.Builders.Randomisers;
using System.Collections.Generic;
using System.Linq;

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
		private readonly IMultipleValuesRandomiser<int> _multipleValuesRandomiser;

		public CountriesGenerator
		(
			IListRandomiser listRandomiser, 
			IRandomiser<int> intRandomiser, 
			IMultipleValuesRandomiser<int> multipleValuesRandomiser
		)
		{
			_listRandomiser = listRandomiser;
			_intRandomiser = intRandomiser;
			_multipleValuesRandomiser = multipleValuesRandomiser;
		}

		public Maybe<Country[]> Generate()
		{
			var nbOfItemsToReturn = _intRandomiser.Randomise(1, 2);
			Country[] items = null;
			if (nbOfItemsToReturn > 1)
			{
				int[] indices = _multipleValuesRandomiser.GetRandomisedValues(new Range<int>(0, Country.Countries.Count - 1), nbOfItemsToReturn);
				items = indices
					.AsEnumerable()
					.Select(i => Country.Countries[i])
					.ToArray();
			}
			else
			{
				items = _listRandomiser.GetRandomisedItems(Country.Countries.ToList(), nbOfItemsToReturn);
			}
			return Maybe.Some(items);
		}
	}
}
