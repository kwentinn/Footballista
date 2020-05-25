using Footballista.BuildingBlocks.Domain.ValueObjects;
using Footballista.Players.Persons;
using Footballista.Players.Positions;
using System.Threading.Tasks;

namespace Footballista.Players.Builders
{
	public interface IPlayerBuilder
	{
		Player Build(Gender? playerGender = null, Country[] countries = null, PlayerPosition playerPosition = null);
		Task<Player> BuildAsync(Gender? playerGender = null, Country[] countries = null, PlayerPosition playerPosition = null);

		Player[] BuildMany(int nbOfPlayers, Gender? playerGender = null, Country[] countries = null, PlayerPosition playerPosition = null);
		Task<Player[]> BuildManyAsync(int nbOfPlayers, Gender? playerGender = null, Country[] countries = null, PlayerPosition playerPosition = null);
		Player[] BuildMany_Parallel(int nbOfPlayers, Gender? playerGender = null, Country[] countries = null, PlayerPosition playerPosition = null);
	}
}
