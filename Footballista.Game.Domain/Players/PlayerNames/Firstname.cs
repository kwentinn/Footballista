using Footballista.BuildingBlocks.Domain;
using Footballista.Game.Domain.Players.PlayerNames.Rules;
using System.Diagnostics;
using System.Globalization;

namespace Footballista.Game.Domain.Players.PlayerNames
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
