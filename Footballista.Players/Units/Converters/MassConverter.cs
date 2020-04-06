using Footballista.Players.Units.Mass;

namespace Footballista.Players.Units.Converters
{
	public class MassConverter : AbstractConverter<Kilogram, Pound>
	{
		public MassConverter() : base(2.204_623, .453_592_37) { }
	}
}
