using Footballista.BuildingBlocks.Domain.ValueObjects;
using Footballista.BuildingBlocks.Domain.ValueObjects.Units;
using Footballista.Players.Persons;
using System.Diagnostics;

namespace Footballista.Players.Evolutions
{
	[DebuggerDisplay("{Percentile} {Country} {Gender} {SystemOfUnitsType}")]
	public abstract class GrowthCurve
	{
		public Percentile Percentile { get; }
		public Country Country { get; }
		public Gender Gender { get; }
		public SystemOfUnitsType SystemOfUnitsType { get; }
		public GrowthCurve(Percentile percentile, Country country, Gender gender, SystemOfUnitsType systemOfUnitsType)
		{
			Percentile = percentile;
			Country = country;
			Gender = gender;
			SystemOfUnitsType = systemOfUnitsType;
		}
	}
}
