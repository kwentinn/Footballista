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

		public Calendar Calendar => CultureInfo.Calendar;

		public DayOfWeek FirstDayOfWeek => CultureInfo.InvariantCulture.DateTimeFormat.FirstDayOfWeek;

		//public string GetDisplayDayOfWeek(DayOfWeek dow)
		//{

		//}
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

		public CareerDateService()
		{
			Console.WriteLine("culture: ");
			Console.WriteLine(CultureInfo);
		}
	}
}
