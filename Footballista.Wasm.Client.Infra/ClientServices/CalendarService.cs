using Footballista.Wasm.Client.Domain.ClientServices;
using Footballista.Wasm.Shared.Data.Calendars;
using Itenso.TimePeriod;
using System.Collections.Generic;

namespace Footballista.Wasm.Client.Infra.ClientServices
{
	public class CalendarService : ICalendarService
	{
		public List<Event> GetEventsForDate(Date date)
		{
			return new List<Event>
			{
				new Event(1, "[L1, J34] MHSC - PSG", new Date(2020, 6, 13), "Match à domicile, 34ème journée du championnat de Ligue 1"),
				new Event(1, "[L1, J35] OL - MHSC", new Date(2020, 6, 20), "Match à l'extérieur, 35ème journée du championnat de Ligue 1"),
				new Event(1, "[L1, J35] OL - MHSC", new Date(2020, 6, 28), "Match à l'extérieur, 36ème journée du championnat de Ligue 1"),
			};
		}
	}
}
