﻿using Footballista.BuildingBlocks.Domain;
using Footballista.Players.PlayerNames.Rules;
using System.Diagnostics;
using System.Globalization;

namespace Footballista.Players.PlayerNames
{
	[DebuggerDisplay("{Value}")]
	public class Firstname : ValueObject
	{
		public string Value { get; }

		public Firstname(string value)
		{
			CheckRule(new FirstNameNotEmptyRule(value));

			Value = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(value);
		}
	}
}
