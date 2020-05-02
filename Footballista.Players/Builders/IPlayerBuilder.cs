using Footballista.BuildingBlocks.Domain.ValueObjects;
using Footballista.Players.Persons;
using Footballista.Players.Positions;

namespace Footballista.Players.Builders
{
	public interface IPlayerBuilder
	{
		Player Build(Gender? playerGender = null, Country[] countries = null, PlayerPosition playerPosition = null);
	}
}
