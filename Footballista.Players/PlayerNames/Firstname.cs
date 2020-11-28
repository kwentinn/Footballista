using Footballista.BuildingBlocks.Domain;
using Footballista.Players.Domain.PlayerNames.Rules;
using System.Diagnostics;
using System.Globalization;

namespace Footballista.Players.Domain.PlayerNames
{
	[DebuggerDisplay("{Value}")]
	public record Firstname : ValueObjectRecord
	{
		public string Value { get; }

		public Firstname(string value)
		{
			CheckRule(new FirstNameNotEmptyRule(value));

			Value = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(value);
		}
	}
}
