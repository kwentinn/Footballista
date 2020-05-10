using System;
using System.Diagnostics;

namespace Footballista.BuildingBlocks.Domain
{
	[DebuggerDisplay("{Min} - {Max}")]
	public class Range<T> : ValueObject
		where T : IComparable<T>
	{
		public T Min { get; }
		public T Max { get; }

		public Range(T min, T max)
		{
			Min = min;
			Max = max;
		}

		public bool IsValueInRange(T value) => IsMinLessOrEqualsValue(value) && IsValueLessOrEqualsMax(value);

		private bool IsMinLessOrEqualsValue(T value) => Min.CompareTo(value) <= 0;
		private bool IsValueLessOrEqualsMax(T value) => value.CompareTo(Max) <= 0;
	}
}
