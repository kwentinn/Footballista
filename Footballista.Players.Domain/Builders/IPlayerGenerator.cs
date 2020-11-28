using Footballista.BuildingBlocks.Domain.ValueObjects;
using Footballista.Players.Domain;
using Footballista.Players.Domain.Persons;
using Footballista.Players.Domain.Positions;
using System.Threading.Tasks;

namespace Footballista.Players.Builders
{
	public interface IPlayerGenerator
	{
		Player Generate(Gender? playerGender = null, Country[] countries = null, PlayerPosition playerPosition = null);
		Task<Player> GenerateAsync(Gender? playerGender = null, Country[] countries = null, PlayerPosition playerPosition = null);

		Player[] GenerateMany(int nbOfPlayers, Gender? playerGender = null, Country[] countries = null, PlayerPosition playerPosition = null);
		Task<Player[]> GenerateManyAsync(int nbOfPlayers, Gender? playerGender = null, Country[] countries = null, PlayerPosition playerPosition = null);
		Player[] GenerateManyParallel(int nbOfPlayers, Gender? playerGender = null, Country[] countries = null, PlayerPosition playerPosition = null);
	}
}
