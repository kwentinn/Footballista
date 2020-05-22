using Footballista.BuildingBlocks.Domain;
using MathNet.Numerics.Random;
using System;
using System.Collections.Generic;

namespace Footballista.Players.Builders.Randomisers
{
	public class IntRandomiser : IRandomiser<int>
	{
		private readonly Guid _id;

		private static readonly IEnumerable<double> _values = SystemRandomSource.DoubleSequence();
		private static object _lock = new object();

		public double Current
		{
			get
			{
				lock (_lock)
				{
					var enumerator = _values.GetEnumerator();
					enumerator.MoveNext();
					return enumerator.Current;
				}
			}
		}

		public IntRandomiser()
		{
			_id = Guid.NewGuid();
		}

		public int Randomise()
		{
			return Convert.ToInt32(Current * int.MaxValue);
		}
		public int Randomise(int min, int max)
		{
			int range = max - min;
			return Convert.ToInt32(Current * range) + min;
		}
		public int Randomise(Range<int> range) => Randomise(range.Lower, range.Upper);
	}
}
