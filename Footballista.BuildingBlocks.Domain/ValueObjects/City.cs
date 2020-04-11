namespace Footballista.BuildingBlocks.Domain.ValueObjects
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