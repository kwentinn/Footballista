using Footballista.Players.Units.Length;

namespace Footballista.Players.Units.Converters
{
	public class LengthConverter : AbstractConverter<Meter, Foot>
	{
		public LengthConverter() : base(3.2808399, 0.3048) { }
	}
}
