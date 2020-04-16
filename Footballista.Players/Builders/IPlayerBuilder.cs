using Footballista.BuildingBlocks.Domain.ValueObjects;
using Footballista.Players.Positions;

namespace Footballista.Players.Builders
{
	public interface IPlayerBuilder
	{
		Player Build(Country country = null, PlayerPosition playerPosition = null);
	}
}
