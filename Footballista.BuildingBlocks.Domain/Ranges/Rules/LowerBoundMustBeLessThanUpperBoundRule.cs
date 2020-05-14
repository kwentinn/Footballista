using System;

namespace Footballista.BuildingBlocks.Domain.Ranges.Rules
{
	public class LowerBoundMustBeLessThanUpperBoundRule<T> : IBusinessRule
		where T : IComparable<T>
	{
		private readonly T _lower;
		private readonly T _upper;

		public string Message => "The lower bound value must be less than the upper bound value.";

		public LowerBoundMustBeLessThanUpperBoundRule(T lower, T upper)
		{
			_lower = lower;
			_upper = upper;
		}

		public bool IsBroken()
		{
			return _lower.CompareTo(_upper) >= 0;
		}
	}
}
