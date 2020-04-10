using Footballista.BuildingBlocks.Domain;

namespace Footballista.Players
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
