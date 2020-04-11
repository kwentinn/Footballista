using System.Diagnostics;

namespace Footballista.BuildingBlocks.Domain.ValueObjects.Units.Length
{
	public class Foot : LengthUnit
	{
		public Foot() : this(0d) { }
		public Foot(double value) : base(value, SystemOfUnitsType.Imperial, "ft") { }
	}
}
