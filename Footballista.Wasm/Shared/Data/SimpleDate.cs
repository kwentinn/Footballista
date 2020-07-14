using Itenso.TimePeriod;

namespace Footballista.Wasm.Shared.Data
{
	public class SimpleDate
	{
		public int Year { get; set; }
		public int Month { get; set; }
		public int Day { get; set; }

		public SimpleDate() { }
		public SimpleDate(int year, int month, int day)
		{
			Year = year;
			Month = month;
			Day = day;
		}
		public Date ToDate()
			=> new Date(Year, Month, Day);

		public override string ToString()
		{
			return ToDate().ToString();
		}
	}
}
