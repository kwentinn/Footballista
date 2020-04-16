using Footballista.BuildingBlocks.Domain;

namespace Footballista.Players.PlayerNames
{
	public class Lastname : ValueObject
	{
		public string Value { get; }
		
		public Lastname(string value)
		{
			Value = value;
		}
	}
}
