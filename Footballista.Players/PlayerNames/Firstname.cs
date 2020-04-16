using Footballista.BuildingBlocks.Domain;

namespace Footballista.Players.PlayerNames
{
	public class Firstname : ValueObject
	{
		public string Value { get; }
		public Firstname(string value)
		{
			Value = value;
		}
	}
}
