using Footballista.BuildingBlocks.Domain;
using Footballista.Players.Domain.PlayerNames.Rules;
using System.Diagnostics;
using System.Globalization;

namespace Footballista.Players.Domain.PlayerNames
{
	[DebuggerDisplay("{Value}")]
	public record Lastname : ValueObjectRecord
	{
		public string Value { get; }

		public Lastname(string value)
		{
			CheckRule(new LastNameNotEmptyRule(value));

			Value = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(value);
		}
	}
}
