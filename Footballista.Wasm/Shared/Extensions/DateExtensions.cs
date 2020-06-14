using System;
using System.Collections.Generic;
using System.Text;
using Itenso.TimePeriod;

namespace Footballista.Wasm.Shared.Extensions
{
	public static class DateExtensions
	{
		public static Date AddMonths(this Date date, int monthsToAdd)
			=> new Date(date.DateTime.AddMonths(monthsToAdd));
		public static Date AddDays(this Date date, int daysToAdd)
			=> new Date(date.DateTime.AddDays(daysToAdd));
	}
}
