using Footballista.BuildingBlocks.Domain;
using Itenso.TimePeriod;
using System;
using System.Diagnostics;

namespace Footballista.Players
{
	[DebuggerDisplay("{Years} yrs.")]
	public class PersonAge : ValueObject, IComparable<PersonAge>
	{
		public static PersonAge Min => new PersonAge(0);
		public static PersonAge Max => new PersonAge(100);

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

		private PersonAge(int years)
		{
			Years = years;
		}
		private PersonAge(double years)
		{
			Years = years;
		}

		public static PersonAge FromYears(int years) => new PersonAge(years);
		public static PersonAge FromYears(double years) => new PersonAge(years);
		public static PersonAge FromMonths(int month) => new PersonAge(Convert.ToDouble(month) / _monthsInYear);
		public static PersonAge FromWeeks(int weeks) => new PersonAge(Convert.ToDouble(weeks) / _weeksInYear);
		public static PersonAge FromDays(int days) => new PersonAge(Convert.ToDouble(days) / _daysInYear);
		public static PersonAge FromDate(Date dob, DateTime? currentDate = null)
		{
			if (currentDate == null) currentDate = DateTime.UtcNow.Date;

			return PersonAge.FromDays(Convert.ToInt32(
				currentDate.Value.Subtract(dob.DateTime).TotalDays
			));
		}

		public int CompareTo(PersonAge other) => Years.CompareTo(other.Years);
	}
}
