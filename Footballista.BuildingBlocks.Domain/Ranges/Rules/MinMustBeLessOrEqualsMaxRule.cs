using System;

namespace Footballista.BuildingBlocks.Domain.Ranges.Rules
{
	public class MinMustBeLessOrEqualsMaxRule<T> : IBusinessRule
		where T : IComparable<T>
	{
		private readonly T _min;
		private readonly T _max;

		public string Message => "Min value must be less than max value.";

		public MinMustBeLessOrEqualsMaxRule(T min, T max)
		{
			_min = min;
			_max = max;
		}

		public bool IsBroken()
		{
			return _min.CompareTo(_max) >= 0;
		}
	}
}
