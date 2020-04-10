using Footballista.BuildingBlocks.Domain;
using Footballista.Players.Units;
using Itenso.TimePeriod;

namespace Footballista.Players
{
	public class TimedPhysicalFeature<T> : ValueObject
		where T : BaseUnit
	{
		public T Value { get; }
		public Date Date { get; }

		public TimedPhysicalFeature(T value, Date date)
		{
			Value = value;
			Date = date;
		}
	}

	//public class 
}
