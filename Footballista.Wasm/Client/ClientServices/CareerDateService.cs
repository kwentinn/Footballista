using Itenso.TimePeriod;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Footballista.Wasm.Shared.Extensions;

namespace Footballista.Wasm.Client.ClientServices
{
	public class CareerDateService
	{
		public CultureInfo CultureInfo => CultureInfo.DefaultThreadCurrentCulture;
		public DateTimeFormatInfo DateTimeInfo => CultureInfo.DateTimeFormat;

		public Calendar Calendar => CultureInfo.Calendar;

		public DayOfWeek FirstDayOfWeek => CultureInfo.DateTimeFormat.FirstDayOfWeek;
		public DayOfWeek LastDayOfWeek => DaysOfWeekEnumerable.Last();

		public string GetDisplayDayOfWeek(DayOfWeek dow) => DateTimeInfo.GetDayName(dow);
		public string GetDisplayDay(Date date) => date.DateTime.ToString("dddd", CultureInfo);
		public string GetDisplayMonth(Date date) => date.DateTime.ToString("MMMM", CultureInfo);
		public string GetDisplayYear(Date date) => date.DateTime.ToString("yyyy", CultureInfo);
		public string GetDisplayFullDate(Date date) => date.DateTime.ToString("D", CultureInfo);


		public int GetNumberOfDays(Date date) => Calendar.GetDaysInMonth(date.Year, date.Month);

		public List<Date> GetDates(Date date)
		{
			Date firstDayOfMonth = new Date(date.Year, date.Month, 1);

			Console.WriteLine(firstDayOfMonth);

			List<Date> dates = new List<Date>();
			for (int i = 0; i < GetNumberOfDays(firstDayOfMonth); i++)
			{
				dates.Add(firstDayOfMonth.AddDays(i));
			}
			return dates;
		}

		public IEnumerable<DayOfWeek> DaysOfWeekEnumerable
			=> Enum.GetValues(typeof(DayOfWeek))
				.OfType<DayOfWeek>()
				.OrderBy(day => day < FirstDayOfWeek);

		public List<Date> GetDaysBeforeFirstDayOfWeek(Date date)
		{
			List<Date> datesBeforeFirstDay = new List<Date>();

			//starts at first day of the month
			var tmpDate = date.FirstDayOfMonth();

			while (tmpDate.DateTime.DayOfWeek != FirstDayOfWeek)
			{
				tmpDate = tmpDate.AddDays(-1);
				datesBeforeFirstDay.Insert(0, tmpDate);
			}

			return datesBeforeFirstDay;
		}
		public List<Date> GetDaysAfterLastDayOfWeek(Date date)
		{
			List<Date> datesAfterLastDay = new List<Date>();

			//starts at first day of the month
			var tmpDate = date.LastDayOfMonth();

			while (tmpDate.DateTime.DayOfWeek != LastDayOfWeek)
			{
				tmpDate = tmpDate.AddDays(1);
				datesAfterLastDay.Add(tmpDate);
			}

			return datesAfterLastDay;
		}
		public List<Date> GetDatesForMonthlyCalendar(
			Date date,
			bool includeDatesBeforeFirstDayOfMonth = true,
			bool includeDatesAfterLastDayOfMonth = true
		)
		{
			List<Date> allDates = new List<Date>();

			if (includeDatesBeforeFirstDayOfMonth)
			{
				var datesBeforeFirstDay = GetDaysBeforeFirstDayOfWeek(date);
				if (datesBeforeFirstDay.Any())
				{
					allDates.AddRange(datesBeforeFirstDay);
				}
			}

			allDates.AddRange(GetDates(date));

			if (includeDatesAfterLastDayOfMonth)
			{
				var datesAfterLastDay = GetDaysAfterLastDayOfWeek(date);
				if (datesAfterLastDay.Any())
				{
					allDates.AddRange(datesAfterLastDay);
				}
			}

			return allDates;
		}
	}
}
