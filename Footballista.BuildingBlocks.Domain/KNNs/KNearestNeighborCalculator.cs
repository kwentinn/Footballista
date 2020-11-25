using Footballista.BuildingBlocks.Domain.KNNs.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Footballista.BuildingBlocks.Domain.KNNs
{
	public class KNearestNeighborCalculator
	{
		private int _x; // la valeur pour laquelle on doit chercher les plus proches voisins
		private int[] _data; // le tableau contenant les données
		private int _k; // le nombre de voisins à chercher/renvoyer

		public KNearestNeighborCalculator(int x, int[] data, int k = 1)
		{
			if (k < 1) throw new ArgumentException(nameof(k));
			if (data is null) throw new ArgumentNullException(nameof(data));
			if (data.Length == 0) throw new ArgumentException(nameof(data));

			_x = x;
			_data = data;
			_k = k;
		}

		public List<KnnResult<int>> Search()
		{
			return _data
				.Select((item, index) => new KnnResult<int>
				(
					new Position(index), 
					item, 
					GetDistance(_x, item)
				))
				.OrderBy(d => d.Distance.Value)
				.Take(_k)
				.ToList();
		}

		private Distance GetDistance(int a, int b) => new Distance(Math.Abs(a - b));
	}
}
