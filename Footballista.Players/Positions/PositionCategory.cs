﻿using Footballista.BuildingBlocks.Domain;
using System.Diagnostics;

namespace Footballista.Players.Positions
{
	[DebuggerDisplay("{Name}")]
	public class PositionCategory : ValueObject
	{
		public string Name { get; }

		private PositionCategory(string name)
		{
			Name = name;
		}

		public static PositionCategory GoalKeeper => new PositionCategory(nameof(GoalKeeper));
		public static PositionCategory Defender => new PositionCategory(nameof(Defender));
		public static PositionCategory Midfielder => new PositionCategory(nameof(Midfielder));
		public static PositionCategory Forward => new PositionCategory(nameof(Forward));
	}
}
