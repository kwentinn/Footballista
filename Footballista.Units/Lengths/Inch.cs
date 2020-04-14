namespace Footballista.Units.Lengths
{
	public class Inch : Length
	{
		public Inch() : this(0) { }
		public Inch(double value) : base(value, SystemOfUnitsType.Imperial, "in") { }
	}
}
