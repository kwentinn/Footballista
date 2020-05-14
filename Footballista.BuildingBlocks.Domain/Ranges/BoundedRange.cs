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
	public class BoundedRange<T> : ValueObject
		where T : IComparable<T>
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

		public BoundedRange(T lower, BoundType lowerBoundType, T upper, BoundType upperBoundType)
			: this(new Bound<T>(lower, lowerBoundType), new Bound<T>(upper, upperBoundType))
		{
		}

		//public static BoundedRange<T> Create(T lower, BoundType lowerBoundType, T upper, BoundType upperBoundType)
		//{
		//	if (lower == null) throw new ArgumentNullException(nameof(lower));
		//	if (upper == null) throw new ArgumentNullException(nameof(upper));

		//	return new BoundedRange<T>(new Bound<T>(lower, lowerBoundType), new Bound<T>(upper, upperBoundType));
		//}

		public bool IsValueInRange(T value) => IsLowerBoundInRange(value) && IsUpperBoundInRange(value);

		private bool IsLowerBoundInRange(T value) => Lower.BoundType switch
		{
			BoundType.Closed => IsLowerBoundLessOrEqualsBoundValue(value),
			BoundType.Open => IsLowerBoundStrictlyLessThanBoundValue(value),
			_ => throw new InvalidOperationException("Incorrect BoundType value"),
		};
		private bool IsUpperBoundInRange(T value) => Upper.BoundType switch
		{
			BoundType.Closed => IsBoundValueLessOrEqualsUpperBound(value),
			BoundType.Open => IsBoundValueStrictlyLessThanUpperBound(value),
			_ => throw new InvalidOperationException("Incorrect BoundType value"),
		};

		private bool IsLowerBoundLessOrEqualsBoundValue(T value) => Lower.BoundValue.CompareTo(value) <= 0;
		private bool IsLowerBoundStrictlyLessThanBoundValue(T value) => Lower.BoundValue.CompareTo(value) < 0;
		private bool IsBoundValueLessOrEqualsUpperBound(T value) => value.CompareTo(Upper.BoundValue) <= 0;
		private bool IsBoundValueStrictlyLessThanUpperBound(T value) => value.CompareTo(Upper.BoundValue) < 0;
	}
}
