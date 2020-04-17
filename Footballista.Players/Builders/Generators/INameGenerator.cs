using Footballista.BuildingBlocks.Domain.ValueObjects;
using Footballista.Players.Persons;
using Footballista.Players.PlayerNames;

namespace Footballista.Players.Builders.Generators
{
	public interface INameGenerator
	{
		Name Generate(Gender gender, Country country);
	}
}
