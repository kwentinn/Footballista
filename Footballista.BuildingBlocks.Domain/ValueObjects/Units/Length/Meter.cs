namespace Footballista.BuildingBlocks.Domain.ValueObjects.Units.Length
{
	public class Meter : LengthUnit
	{
		public Meter() : this(0d) { }
		public Meter(double value) : base(value, SystemOfUnitsType.SI, "m") { }
	}
}
