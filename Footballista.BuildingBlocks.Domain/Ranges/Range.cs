using Footballista.BuildingBlocks.Domain.Ranges.Rules;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Footballista.BuildingBlocks.Domain
{
	/// <summary>
	/// Represents a closed range from a Lower bound to an Upper bound.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	[DebuggerDisplay("{Lower} - {Upper}")]
	public record Range<T> : ValueObjectRecord where T : IComparable<T>
	{
		/// <summary>
		/// Lower bound
		/// </summary>
		public T Lower { get; }

		/// <summary>
		/// Upper bound
		/// </summary>
		public T Upper { get; }

		public Range(T lower, T upper)
		{
			CheckRule(new LowerBoundMustBeLessThanUpperBoundRule<T>(lower, upper));

			Lower = lower;
			Upper = upper;
		}

		public bool IsValueInRange(T value) => IsMinLessOrEqualsValue(value) && IsValueLessOrEqualsMax(value);

		private bool IsMinLessOrEqualsValue(T value) => Lower.CompareTo(value) <= 0;
		private bool IsValueLessOrEqualsMax(T value) => value.CompareTo(Upper) <= 0;


		public Range<T> Merge(Range<T> other)
		{
			var ranges = new List<Range<T>> { this, other };
			return MergeRanges(ranges);
		}

		public static Range<T> MergeRanges(IEnumerable<Range<T>> ranges)
		{
			T lower = Range.GetLowestValue(ranges);
			T upper = Range.GetHighestValue(ranges);
			return new Range<T>(lower, upper);
		}
		public static T GetLowestValue(IEnumerable<Range<T>> ranges)
		{
			if (ranges is null) throw new ArgumentNullException(nameof(ranges));

			return ranges.Min(r => r.Lower);
		}
		public static T GetHighestValue(IEnumerable<Range<T>> ranges)
		{
			if (ranges is null) throw new ArgumentNullException(nameof(ranges));
			
			return ranges.Max(r => r.Upper);
		}
	}
	public static class Range
	{
		public static T GetLowestValue<T>(IEnumerable<Range<T>> ranges) where T : IComparable<T>
			=> Range<T>.GetLowestValue(ranges);
		public static T GetHighestValue<T>(IEnumerable<Range<T>> ranges) where T : IComparable<T>
			=> Range<T>.GetHighestValue(ranges);
	}
}
