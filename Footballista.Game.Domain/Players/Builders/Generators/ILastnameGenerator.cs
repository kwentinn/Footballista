using Footballista.BuildingBlocks.Domain.ValueObjects;
using Footballista.Game.Domain.Players.Persons;
using Footballista.Game.Domain.Players.PlayerNames;
using System.Threading.Tasks;

namespace Footballista.Players.Builders.Generators
{
	public interface ILastnameGenerator
	{
		Lastname Generate(Gender gender, Country country);
		Task<Lastname> GenerateAsync(Gender gender, Country country);
	}
}
