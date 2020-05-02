using Footballista.BuildingBlocks.Domain.KNNs.Models;
using Footballista.BuildingBlocks.Domain.Percentiles;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Footballista.BuildingBlocks.Domain.KNNs
{
	public class PercentileKNearestNeighborCalculator
	{
		private Percentile _x; // le point pour lequel on doit chercher les plus proches voisins
		private Percentile[] _data; // le tableau contenant les données
		private int _k; // le nombre de voisins à chercher/renvoyer

		public PercentileKNearestNeighborCalculator(Percentile x, Percentile[] data, int k = 1)
		{
			if (k < 1) throw new ArgumentException(nameof(k));
			if (data is null) throw new ArgumentNullException(nameof(data));
			if (data.Length == 0) throw new ArgumentException(nameof(data));

			_x = x;
			_data = data;
			_k = k;
		}

		public List<KnnResult<Percentile>> Search()
		{
			return _data
				.Select((item, index) => new KnnResult<Percentile>
				(
					new Position(index),
					item,
					getDistance(_x, item)
				))
				.OrderBy(d => d.Distance.Value)
				.ThenBy(d => d.Position.IndexValue)
				.Take(_k)
				.ToList();
		}

		private Distance getDistance(Percentile a, Percentile b)
			=> new Distance(Math.Abs(a.Value - b.Value));
	}
}
