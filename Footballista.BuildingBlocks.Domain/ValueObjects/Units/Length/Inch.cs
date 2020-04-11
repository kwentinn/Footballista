namespace Footballista.BuildingBlocks.Domain.ValueObjects.Units.Length
{
	public class Inch : LengthUnit
	{
		public Inch() : this(0) { }
		public Inch(double value) : base(value, SystemOfUnitsType.Imperial, "in") { }
	}
}
