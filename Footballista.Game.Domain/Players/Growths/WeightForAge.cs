using Footballista.BuildingBlocks.Domain.ValueObjects;

namespace Footballista.Game.Domain.Players.Growths
{
	public class WeightForAge
	{
		public PersonAge Age { get; }
		public UnitsNet.Mass Mass { get; }

		public WeightForAge(int ageInYears, UnitsNet.Mass mass)
		{
			Age = PersonAge.FromYears(ageInYears);
			Mass = mass;
		}
	}
}
