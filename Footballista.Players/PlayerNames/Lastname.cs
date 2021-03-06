﻿using Footballista.BuildingBlocks.Domain;
using Footballista.Players.PlayerNames.Rules;
using System.Diagnostics;
using System.Globalization;

namespace Footballista.Players.PlayerNames
{
	[DebuggerDisplay("{Value}")]
	public class Lastname : ValueObject
	{
		public string Value { get; }

		public Lastname(string value)
		{
			CheckRule(new LastNameNotEmptyRule(value));

			Value = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(value);
		}
	}
}
