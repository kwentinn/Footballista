using Itenso.TimePeriod;

namespace Footballista.Wasm.Shared.Extensions
{
	public static class DateExtensions
	{
		/// <summary>
		/// Add years to the current date
		/// </summary>
		/// <param name="date"></param>
		/// <param name="yearsToAdd"></param>
		/// <returns></returns>
		public static Date AddYears(this Date date, int yearsToAdd)
			=> new Date(date.DateTime.AddYears(yearsToAdd));

		/// <summary>
		/// Add months to the current date
		/// </summary>
		/// <param name="date"></param>
		/// <param name="monthsToAdd"></param>
		/// <returns></returns>
		public static Date AddMonths(this Date date, int monthsToAdd)
			=> new Date(date.DateTime.AddMonths(monthsToAdd));

		/// <summary>
		/// Add days to the current date
		/// </summary>
		/// <param name="date"></param>
		/// <param name="daysToAdd"></param>
		/// <returns></returns>
		public static Date AddDays(this Date date, int daysToAdd)
			=> new Date(date.DateTime.AddDays(daysToAdd));

		/// <summary>
		/// Returns the first day of the current date's month
		/// </summary>
		/// <param name="date"></param>
		/// <returns></returns>
		public static Date FirstDayOfMonth(this Date date) 
			=> new Date(date.Year, date.Month);

		/// <summary>
		/// Returns the last day of the current date's month
		/// </summary>
		/// <param name="date"></param>
		/// <returns></returns>
		public static Date LastDayOfMonth(this Date date) 
			=> FirstDayOfMonth(date).AddMonths(1).AddDays(-1);

	}
}
