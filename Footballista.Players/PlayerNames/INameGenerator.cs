using Footballista.BuildingBlocks.Domain.ValueObjects;

namespace Footballista.Players.PlayerNames
{
	public interface INameGenerator
	{
		Name Generate(Country country);
	}
	public class NameGenerator : INameGenerator
	{
		public NameGenerator()
		{
		}
		public Name Generate(Country country)
		{
			throw new System.NotImplementedException();
		}
	}
}
