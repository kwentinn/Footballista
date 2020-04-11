using Footballista.BuildingBlocks.Domain.ValueObjects.Units.Mass;

namespace Footballista.BuildingBlocks.ValueObjects.Units.Converters
{
	public class MassConverter : AbstractConverter<Kilogram, Pound>
	{
		public MassConverter() : base(2.204_623, .453_592_37) { }
	}
}
