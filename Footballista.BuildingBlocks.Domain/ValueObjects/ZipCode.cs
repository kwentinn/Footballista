namespace Footballista.BuildingBlocks.Domain.ValueObjects
{
	public class ZipCode : ValueObject
	{
		public string Value { get; }

		public ZipCode(string value)
		{
			Value = value;
		}
	}
}
