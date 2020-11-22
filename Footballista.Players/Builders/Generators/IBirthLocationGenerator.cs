using Footballista.BuildingBlocks.Domain.ValueObjects;
using System.Threading.Tasks;

namespace Footballista.Players.Builders.Generators
{
	public interface IBirthLocationGenerator
	{
		Location Generate(Country country);
		Task<Location> GenerateAsync(Country country);
	}
}
