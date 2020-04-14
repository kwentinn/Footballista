namespace Footballista.Units.Masses
{
	public class Kilogram : Mass
	{
		public Kilogram() : this(0) { }
		public Kilogram(double value) : base(value, SystemOfUnitsType.SI, "kg")
		{
		}
	}
}
