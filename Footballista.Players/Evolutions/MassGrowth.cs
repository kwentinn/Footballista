using Footballista.BuildingBlocks.Domain.ValueObjects.Units.Mass;

namespace Footballista.Players.Evolutions
{
	public class MassGrowth : Growth<IMassUnit>
	{
		public MassGrowth(int ageInYear, IMassUnit mass) : this(new AgeInYear(ageInYear), mass) { }
		public MassGrowth(AgeInYear age, IMassUnit mass) : base(age, mass) { }
	}
}
