using System;
using System.Diagnostics;
using Date = Itenso.TimePeriod.Date;

namespace Footballista.BuildingBlocks.Domain.ValueObjects
{
	[DebuggerDisplay("{System.Math.Round(Years, 1)} yrs.")]
	public record PersonAge : ValueObjectRecord, IComparable<PersonAge>
	{
		public static PersonAge Min => new PersonAge(0);
		public static PersonAge Max => new PersonAge(100);

		private const double _monthsInYear = 12d;
		private const double _weeksInYear = 52d;
		private const double _daysInYear = 365d;

		public double Years { get; }

		public double Months => Years * _monthsInYear;

		public double Weeks => Years * _weeksInYear;

		public double Days => Years * _daysInYear;

		private PersonAge(int years)
		{
			Years = years;
		}
		private PersonAge(double years)
		{
			Years = years;
		}

		public static implicit operator double(PersonAge personAge)
        {
			return personAge.Years;
        }
		public static implicit operator PersonAge(double age)
        {
			return FromYears(age);
        }

		public static PersonAge FromYears(int years) => new PersonAge(years);
		public static PersonAge FromYears(double years) => new PersonAge(years);
		public static PersonAge FromMonths(int month) => new PersonAge(Convert.ToDouble(month) / _monthsInYear);
		public static PersonAge FromWeeks(int weeks) => new PersonAge(Convert.ToDouble(weeks) / _weeksInYear);
		public static PersonAge FromDays(int days) => new PersonAge(Convert.ToDouble(days) / _daysInYear);
		public static PersonAge FromDate(Date dob, DateTime? currentDate = null)
		{
			if (currentDate == null) currentDate = DateTime.UtcNow.Date;
			return FromDays(Convert.ToInt32(
				currentDate.Value.Subtract(dob.DateTime).TotalDays
			));
		}

		public int CompareTo(PersonAge other) => Years.CompareTo(other.Years);

		public static PersonAge operator +(PersonAge age, Duration duration)
		{
			if (age is null) throw new ArgumentNullException(nameof(age));
			if (duration is null) throw new ArgumentNullException(nameof(duration));

			return FromYears(age.Years + duration.Years);
		}
		public static PersonAge operator -(PersonAge age, Duration duration)
			=> FromYears(age.Years - duration.Years);
		public static bool operator >(PersonAge left, PersonAge right) => left.CompareTo(right) > 0;
		public static bool operator <(PersonAge left, PersonAge right) => left.CompareTo(right) < 0;
		public static bool operator >=(PersonAge left, PersonAge right) => left.CompareTo(right) >= 0;
		public static bool operator <=(PersonAge left, PersonAge right) => left.CompareTo(right) <= 0;

		/// <summary>
		/// Returns a new instance of <see cref="PersonAge"/> with rounded years.
		/// </summary>
		/// <returns></returns>
		public PersonAge AsRoundedYears() => new PersonAge(Math.Round(Years, 0));


	}
}
