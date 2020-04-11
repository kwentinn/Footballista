using Footballista.BuildingBlocks.Domain.ValueObjects.Units.Mass;

namespace Footballista.Players.Evolutions
{
	public class MassGrowth : Growth<MassUnit>
	{
		public MassGrowth(AgeInYear age, MassUnit mass) : base(age, mass) { }
	}
}
