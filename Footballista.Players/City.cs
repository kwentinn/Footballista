using Footballista.BuildingBlocks.Domain;

namespace Footballista.Players
{
	public class City : ValueObject
	{
		public string Value { get; }

		public City(string value)
		{
			Value = value;
		}
	}
}