using Footballista.BuildingBlocks.Domain.ValueObjects;
using Footballista.Game.Domain.Players.Persons;
using Footballista.Game.Domain.Players.PlayerNames;
using System.Threading.Tasks;

namespace Footballista.Players.Builders.Generators
{
	public interface IFirstnameGenerator
	{
		Firstname Generate(Gender gender, Country country);
		Task<Firstname> GenerateAsync(Gender gender, Country country);
	}
}
