﻿using Footballista.BuildingBlocks.Domain.KNNs.Models;
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

		public Maybe<List<KnnResult<Percentile>>> Search()
		{
			return Maybe.Some(_data
				.Select((item, index) => new KnnResult<Percentile>
				(
					new Position(index),
					item,
					getDistance(_x, item)
				))
				.OrderBy(d => d.Distance.Value)
				.ThenBy(d => d.Position.IndexValue)
				.Take(_k)
				.ToList());
		}

		private Distance getDistance(Percentile a, Percentile b)
			=> new Distance(Math.Abs(a.Value - b.Value));
	}
	public class PercentileKNearestNeighborCalculator<T>
	{
		private Percentile _x; // le point pour lequel on doit chercher les plus proches voisins
		private PercentileData<T>[] _data; // le tableau contenant les données
		private int _k; // le nombre de voisins à chercher/renvoyer

		public PercentileKNearestNeighborCalculator(Percentile x, PercentileData<T>[] data, int k = 1)
		{
			if (k < 1) throw new ArgumentException(nameof(k));
			if (data is null) throw new ArgumentNullException(nameof(data));
			if (data.Length == 0) throw new ArgumentException(nameof(data));

			_x = x;
			_data = data;
			_k = k;
		}

		public Maybe<List<KnnResult<PercentileData<T>>>> GetNearestNeighbours()
		{
			return Maybe.Some(_data
				.Select((item, index) => new KnnResult<PercentileData<T>>
				(
					new Position(index),
					item,
					_x.GetDistance(item.Percentile) // getDistance(_x, item.Percentile)
				))
				.OrderBy(r => r.Distance.Value)
				.ThenBy(r => r.Position.IndexValue)
				.Take(_k)
				.ToList());;
		}

		private Distance getDistance(Percentile a, Percentile b)
			=> new Distance(Math.Abs(a.Value - b.Value));
	}
	public class PercentileNearestNeighbourCalculator<T> : PercentileKNearestNeighborCalculator<T>
	{
		public PercentileNearestNeighbourCalculator
		(
			Percentile x,
			PercentileData<T>[] data
		) : base(x, data, 1)
		{
		}

		KnnResult<PercentileData<T>> GetNearestNeighbour() 
			=> GetNearestNeighbours()
				.Value
				.FirstOrDefault();

		public T GetNearestNeighbourUnderlyingType() 
			=> GetNearestNeighbour()
				.Value
				.Object;
	}
}
