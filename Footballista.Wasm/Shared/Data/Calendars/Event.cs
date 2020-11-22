using Itenso.TimePeriod;

namespace Footballista.Wasm.Shared.Data.Calendars
{
	public class Event
	{
		public int Id { get; }
		public string Name { get; }
		public Date Date { get; }
		public string Description { get; }

		public Event(int id, string name, Date date, string description = null)
		{
			Id = id;
			Name = name;
			Date = date;
			Description = description;
		}
	}
}
