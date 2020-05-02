namespace Footballista.BuildingBlocks.Domain.ValueObjects
{
	public class City : ValueObject
	{
		public string Name { get; }

		public City(string name)
		{
			Name = name;
		}
	}
}