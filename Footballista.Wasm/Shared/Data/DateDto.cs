using Itenso.TimePeriod;
using System;
using System.Collections.Generic;
using System.Text;

namespace Footballista.Wasm.Shared.Data
{
	public class DateDto
	{
		public int Year { get; set; }
		public int Month { get; set; }
		public int Day { get; set; }

		public DateDto() { }
		public DateDto(int year, int month, int day)
		{
			Year = year;
			Month = month;
			Day = day;
		}
		public Date ToDate()
			=> new Date(Year, Month, Day);
	}
}
