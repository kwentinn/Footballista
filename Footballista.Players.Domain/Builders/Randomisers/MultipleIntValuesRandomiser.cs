using Footballista.BuildingBlocks.Domain;
using MathNet.Numerics.Random;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Footballista.Players.Builders.Randomisers
{
	public class MultipleIntValuesRandomiser : IMultipleValuesRandomiser<int>
	{
		private static readonly IEnumerable<double> _values = SystemRandomSource.DoubleSequence();
		private static IEnumerator<double> _enumerator;
		private static object _lock = new object();

		public MultipleIntValuesRandomiser()
		{
		}

		public int[] GetRandomisedValues(Range<int> intRange, int numberOfItemsToGenerate, bool allowIdenticalValues = false)
		{
			var ints = new List<int>();
			var doubles = GetCurrentValues(numberOfItemsToGenerate);
			foreach (var dbl in doubles)
			{
				int value = GetValueFromDouble(intRange, dbl);
				if (!allowIdenticalValues)
				{
					int maxIterations = 3;
					int i = 0;
					while (ints.Contains(value) && i < maxIterations)
					{
						value = GetValueFromDouble(intRange, dbl);
						i++;
					}
				}
				ints.Add(value);
			}
			return ints.ToArray();
		}

		private double[] GetCurrentValues(int numberOfItems)
		{
			lock (_lock)
			{
				var items = new List<double>();
				_enumerator ??= _values.GetEnumerator();
				for (int i = 0; i < numberOfItems; i++)
				{
					_enumerator.MoveNext();
					items.Add(_enumerator.Current);
				}
				return items.ToArray();
			}
		}
		private int GetValueFromDouble(Range<int> intRange, double dbl)
		{
			int range = intRange.Upper - intRange.Lower;
			return Convert.ToInt32(dbl * range) + intRange.Lower;
		}

	}
}
