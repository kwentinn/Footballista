using Footballista.BuildingBlocks.Domain;
using Itenso.TimePeriod;
using System;
using System.Diagnostics;

namespace Footballista.Players
{
	[DebuggerDisplay("{Years} yrs.")]
	public class Age : ValueObject
	{
		public static Age Min => new Age(0);
		public static Age Max => new Age(100);

		private static double _monthsInYear = 12d;
		private static double _weeksInYear = 52d;
		private static double _daysInYear = 365d;

		public double Years { get; }

		[IgnoreMember]
		public double Months => Years * _monthsInYear;

		[IgnoreMember]
		public double Weeks => Years * _weeksInYear;

		[IgnoreMember]
		public double Days => Years * _daysInYear;

		private Age(int years)
		{
			Years = years;
		}
		private Age(double years)
		{
			Years = years;
		}

		public static Age FromYears(int years) => new Age(years);
		public static Age FromMonths(int month) => new Age(Convert.ToDouble(month) / _monthsInYear);
		public static Age FromWeeks(int weeks) => new Age(Convert.ToDouble(weeks) / _weeksInYear);
		public static Age FromDays(int days) => new Age(Convert.ToDouble(days) / _daysInYear);
		public static Age FromDate(Date dob, DateTime? currentDate = null)
		{
			if (currentDate == null) currentDate = DateTime.UtcNow.Date;

			return Age.FromDays(Convert.ToInt32(
				currentDate.Value.Subtract(dob.DateTime).TotalDays
			));
		}

		public static Age FromYears(double years) => new Age(years);
	}
}
