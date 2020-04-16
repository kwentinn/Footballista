using Footballista.BuildingBlocks.Domain.ValueObjects;
using UnitsNet;

namespace Footballista.Players.Builders.Generators
{
	public interface IStatureGenerator
	{
		Length Generate(Country country);
	}
}
