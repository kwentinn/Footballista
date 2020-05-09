using System.Diagnostics;

namespace Footballista.BuildingBlocks.Domain.ValueObjects
{
	[DebuggerDisplay("{Name}")]
	public class City : ValueObject
	{
		public string Name { get; }

		public City(string name)
		{
			Name = name;
		}
	}
}