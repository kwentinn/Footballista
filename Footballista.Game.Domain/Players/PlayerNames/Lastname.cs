﻿using Footballista.BuildingBlocks.Domain;
using Footballista.Game.Domain.Players.PlayerNames.Rules;
using System.Diagnostics;
using System.Globalization;

namespace Footballista.Game.Domain.Players.PlayerNames
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