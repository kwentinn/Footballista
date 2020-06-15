using Footballista.Wasm.Shared.Data.Calendars;
using Itenso.TimePeriod;
using System.Collections.Generic;

namespace Footballista.Wasm.Client.ClientServices
{
	public class CalendarService
	{
		public List<Event> GetEventsForDate(Date date)
		{
			return new List<Event>
			{
				new Event(1, "[L1, J34] MHSC - PSG", new Date(2020, 6, 13)),
				new Event(1, "[L1, J35] OL - MHSC", new Date(2020, 6, 20)),
				new Event(1, "[L1, J35] OL - MHSC", new Date(2020, 6, 28)),
			};
		}
	}
}
