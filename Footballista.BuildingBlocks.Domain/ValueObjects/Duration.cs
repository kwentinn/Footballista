using Footballista.BuildingBlocks.Domain.ValueObjects.Rules;
using System;
using System.Diagnostics;

namespace Footballista.BuildingBlocks.Domain.ValueObjects
{
	[DebuggerDisplay("{System.Math.Round(Years, 2)} yrs.")]
	public class Duration : ValueObject, IComparable<Duration>
	{
		public double Years { get; }

		private Duration(double years)
		{
			CheckRule(new DurationMustBeGreaterThanZeroRule(years));

			Years = years;
		}

		public static Duration FromYears(double years) => new Duration(years);

		public int CompareTo(Duration other) => Years.CompareTo(other.Years);

		public static Duration FromAgeRange(Range<PersonAge> ageRange)
			=> FromYears(ageRange.Upper.Years - ageRange.Lower.Years);

		public static Duration FromMonths(int months) => FromYears(Convert.ToDouble(months) / 12d);
	}
}
