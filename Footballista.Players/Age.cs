using Footballista.BuildingBlocks.Domain;
using System;
using System.Diagnostics;

namespace Footballista.Players
{
	[DebuggerDisplay("{Years} yrs.")]
	public class Age : ValueObject
	{
		private static float _monthsInYear = 12f;
		private static float _weeksInYear = 52f;
		private static float _daysInYear = 365f;

		public float Years { get; }

		[IgnoreMember]
		public float Months => Years * _monthsInYear;

		[IgnoreMember]
		public float Weeks => Years * _weeksInYear;

		[IgnoreMember]
		public float Days => Years * _daysInYear;

		private Age(int years)
		{
			Years = years;
		}
		private Age(float years)
		{
			Years = years;
		}

		public static Age FromYears(int years) => new Age(years);
		public static Age FromMonths(int month) => new Age(Convert.ToSingle(month) / _monthsInYear);
		public static Age FromWeeks(int weeks) => new Age(Convert.ToSingle(weeks) / _weeksInYear);
		public static Age FromDays(int days) => new Age(Convert.ToSingle(days) / _daysInYear);
	}
}
