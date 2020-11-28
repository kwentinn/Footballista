using Footballista.BuildingBlocks.Domain;
using Footballista.BuildingBlocks.Domain.KNNs;
using Footballista.BuildingBlocks.Domain.KNNs.Models;
using Footballista.BuildingBlocks.Domain.Percentiles;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Footballista.Players.Domain.Growths
{
	public abstract class AbstractPercentileGrowthSet
	{
		public ReadOnlyCollection<PercentileGrowth> Growths => _growths.AsReadOnly();
		private readonly List<PercentileGrowth> _growths = new List<PercentileGrowth>();

		protected AbstractPercentileGrowthSet(List<PercentileGrowth> growths)
		{
			_growths = growths ?? throw new ArgumentNullException(nameof(growths));
		}

		public PercentileGrowth GetForPercentile(Percentile percentile)
		{
			var calculator = new PercentileKNearestNeighborCalculator
			(
				percentile,
				_growths.Select(pg => pg.Percentile).ToArray()
			);

			Maybe<List<KnnResult<Percentile>>> resultList = calculator.Search();
			resultList.ValueOrThrow(new ApplicationException("No value returned"));

			KnnResult<Percentile> knnResult = resultList.Value[0];

			return _growths[knnResult.Position.IndexValue];
		}
	}
}
