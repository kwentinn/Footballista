using Footballista.BuildingBlocks.Domain.ValueObjects;
using UnitsNet;

namespace Footballista.Players.Builders.Generators
{
	public interface IWeightGenerator
	{
		Mass Generate(Country country);
	}
}
