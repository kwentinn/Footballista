namespace Footballista.Units
{
	public interface IUnit
	{
		double Value { get; }
		string Abbreviation { get; }
		BaseUnitType BaseUnitType { get; }
		SystemOfUnitsType SystemOfUnitsType { get; }
	}
}
