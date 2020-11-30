using Footballista.BuildingBlocks.Domain.Ranges.Rules;
using System;
using System.Diagnostics;

namespace Footballista.BuildingBlocks.Domain
{
	/// <summary>
	/// Represents a range from a Lower bound to an Upper bound.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	[DebuggerDisplay("{Lower} - {Upper}")]
    public record BoundedRange<T> : ValueObjectRecord where T :  IComparable<T>
	{
		/// <summary>
		/// Lower bound
		/// </summary>
		public Bound<T> Lower { get; }

		/// <summary>
		/// Upper bound
		/// </summary>
		public Bound<T> Upper { get; }

		public BoundedRange(Bound<T> lower, Bound<T> upper)
		{
			if (lower == null) throw new ArgumentNullException(nameof(lower));
			if (upper == null) throw new ArgumentNullException(nameof(upper));

			CheckRule(new LowerBoundMustBeLessThanUpperBoundRule<T>(lower.BoundValue, upper.BoundValue));

			Lower = lower;
			Upper = upper;
		}

		public static BoundedRange<T> CreateIncluded(T lower, T upper)
			=> new BoundedRange<T>(new IncludingBound<T>(lower), new IncludingBound<T>(upper));

		public bool IsValueInRange(T value) => IsLowerBoundInRange(value) && IsUpperBoundInRange(value);

		private bool IsLowerBoundInRange(T value)
		{
			if (Lower is IncludingBound<T>)
			{
				return IsLowerBoundLessOrEqualsBoundValue(value);
			}
			if (Lower is ExcludingBound<T>)
            {
				return IsLowerBoundStrictlyLessThanBoundValue(value);
			}
			throw new InvalidOperationException("Invalid Bound");
		}

		private bool IsUpperBoundInRange(T value)
		{
			if (Upper is IncludingBound<T>)
			{
				return IsBoundValueLessOrEqualsUpperBound(value);
			}
			if (Upper is ExcludingBound<T>)
			{
				return IsBoundValueStrictlyLessThanUpperBound(value);
			}
			throw new InvalidOperationException("Invalid Bound");
		}

		private bool IsLowerBoundLessOrEqualsBoundValue(T value) => Lower.BoundValue.CompareTo(value) <= 0;
		private bool IsLowerBoundStrictlyLessThanBoundValue(T value) => Lower.BoundValue.CompareTo(value) < 0;
		private bool IsBoundValueLessOrEqualsUpperBound(T value) => value.CompareTo(Upper.BoundValue) <= 0;
		private bool IsBoundValueStrictlyLessThanUpperBound(T value) => value.CompareTo(Upper.BoundValue) < 0;
	}
}
