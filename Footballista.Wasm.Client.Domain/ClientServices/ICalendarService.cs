using Footballista.Wasm.Shared.Data.Calendars;
using Itenso.TimePeriod;
using System.Collections.Generic;

namespace Footballista.Wasm.Client.Domain.ClientServices
{
	public interface ICalendarService
	{
		List<Event> GetEventsForDate(Date date);
	}
}