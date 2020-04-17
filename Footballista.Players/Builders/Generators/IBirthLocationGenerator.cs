using Footballista.BuildingBlocks.Domain.ValueObjects;

namespace Footballista.Players.Builders.Generators
{
	public interface IBirthLocationGenerator
	{
		Location Generate(Country country);
	}
}
