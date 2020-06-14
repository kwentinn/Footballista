using Itenso.TimePeriod;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Footballista.Wasm.Client.ClientServices
{
	public class CareerDateService
	{
		public CultureInfo CultureInfo => CultureInfo.DefaultThreadCurrentCulture;

		public Calendar Calendar => CultureInfo.Calendar;

		public DayOfWeek FirstDayOfWeek => CultureInfo.InvariantCulture.DateTimeFormat.FirstDayOfWeek;

		public string GetDisplayMonth(Date date) => date.DateTime.ToString("MMMM", CultureInfo.InvariantCulture);

		public string GetDisplayYear(Date date) => date.DateTime.ToString("yyyy", CultureInfo.InvariantCulture);

		public int GetNumberOfDays(Date date) => Calendar.GetDaysInMonth(date.Year, date.Month);

		public List<Date> GetDates(Date date)
		{
			List<Date> dates = new List<Date>();
			for (int i = 0; i < GetNumberOfDays(date); i++)
			{
				dates.Add(new Date(date.DateTime.AddDays(i)));
			}
			return dates;
		}

		public IEnumerable<DayOfWeek> DaysOfWeekEnumerable
			=> Enum.GetValues(typeof(DayOfWeek))
				.OfType<DayOfWeek>()
				.OrderBy(day => day < FirstDayOfWeek);

		public CareerDateService()
		{
			Console.WriteLine("culture: ");
			Console.WriteLine(CultureInfo);
		}
	}
}
