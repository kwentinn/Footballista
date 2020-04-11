using Footballista.BuildingBlocks.Domain.ValueObjects.Units;

namespace Footballista.Players.Evolutions
{
	public interface IGrowth
	{
		AgeInYear Age { get; }
		IUnit Value { get; }
	}
}
