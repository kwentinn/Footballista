using Footballista.Players.Builders.Randomisers;
using Footballista.Players.Domain.Growths;
using Footballista.Players.Domain.Persons;
using System.Collections.Generic;
using System.Linq;

namespace Footballista.Players.Builders.Generators
{
	public interface IGrowthSetGenerator
	{
		PercentileGrowth GeneratePercentileGrowth(Gender gender);
	}
	public class GrowthSetGenerator : IGrowthSetGenerator
	{
		private readonly IPercentileGrowthSetRepository _percentileGrowthSetRepository;
		private readonly IListRandomiser _listRandomiser;

		public GrowthSetGenerator
		(
			IPercentileGrowthSetRepository percentileGrowthSetRepository,
			IListRandomiser listRandomiser
		)
		{
			_percentileGrowthSetRepository = percentileGrowthSetRepository;
			_listRandomiser = listRandomiser;
		}

		public PercentileGrowth GeneratePercentileGrowth(Gender gender)
		{
			AbstractPercentileGrowthSet growthSet = _percentileGrowthSetRepository.GetPercentileGrowthSet(gender);
			if (growthSet == null)
				return null;

			List<PercentileGrowth> items = growthSet.Growths.ToList();

			return _listRandomiser.GetRandomisedItem(items);
		}
	}
}
