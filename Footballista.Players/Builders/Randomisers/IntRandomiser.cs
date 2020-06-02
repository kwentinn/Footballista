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
		private static IEnumerator<double> _enumerator;
		private static object _lock = new object();

		private double Current
		{
			get
			{
				lock (_lock)
				{
					_enumerator ??= _values.GetEnumerator();
					_enumerator.MoveNext();
					return _enumerator.Current;
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
