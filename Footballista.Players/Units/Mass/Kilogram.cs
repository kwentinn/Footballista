namespace Footballista.Players.Units.Mass
{
	public class Kilogram : MassUnit
	{
		public Kilogram() : this(0) { }
		public Kilogram(double value) : base(value, SystemOfUnitsType.SI, "kg")
		{
		}
	}
}
