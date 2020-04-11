namespace Footballista.BuildingBlocks.Domain.ValueObjects.Units.Length
{
	public class Meter : LengthUnit
	{
		public Meter() : this(0d) { }
		public Meter(double value) : base(value, SystemOfUnitsType.SI, "m") { }
	}
	//public class Centimer : LengthUnit
	//{
	//	public Centimer() : this(0d) { }
	//	public Centimer(double valueInCentimers) : base(valueInCentimers / 100.0, SystemOfUnitsType.SI, "cm") { }
	//}
}
