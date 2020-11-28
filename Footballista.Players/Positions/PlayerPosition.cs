﻿using Footballista.BuildingBlocks.Domain;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace Footballista.Players.Domain.Positions
{
	[DebuggerDisplay("{Name}")]
	public record PlayerPosition : ValueObjectRecord
	{
		public string Name { get; }
		public PositionCategory PositionCategory { get; }

		private PlayerPosition(string name) : this(name, PositionCategory.None) { }
		private PlayerPosition(string name, PositionCategory positionCategory)
		{
			Name = name;
			PositionCategory = positionCategory;
		}

		// goalie
		public static PlayerPosition GoalKeeper => new PlayerPosition(nameof(GoalKeeper), PositionCategory.GoalKeeper);

		//defenders
		public static PlayerPosition CentreBack => new PlayerPosition(nameof(CentreBack), PositionCategory.Defender);
		public static PlayerPosition Sweeper => new PlayerPosition(nameof(Sweeper), PositionCategory.Defender);
		public static PlayerPosition FullBack => new PlayerPosition(nameof(FullBack), PositionCategory.Defender);
		public static PlayerPosition WingBack => new PlayerPosition(nameof(WingBack), PositionCategory.Defender);

		// midfielders
		public static PlayerPosition CentreMidfield => new PlayerPosition(nameof(CentreMidfield), PositionCategory.Midfielder);
		public static PlayerPosition DefensiveMidfield => new PlayerPosition(nameof(DefensiveMidfield), PositionCategory.Midfielder);
		public static PlayerPosition AttackingMidfield => new PlayerPosition(nameof(AttackingMidfield), PositionCategory.Midfielder);
		public static PlayerPosition WideMidfield => new PlayerPosition(nameof(WideMidfield), PositionCategory.Midfielder);

		// Forwards
		public static PlayerPosition CentreForward => new PlayerPosition(nameof(CentreForward), PositionCategory.Forward);
		public static PlayerPosition SecondStriker => new PlayerPosition(nameof(SecondStriker), PositionCategory.Forward);
		public static PlayerPosition Winger => new PlayerPosition(nameof(Winger), PositionCategory.Forward);

		public static PlayerPosition Any => new PlayerPosition(nameof(Any));

		// all positions
		private readonly static List<PlayerPosition> _allPositions = new List<PlayerPosition>
		{
			GoalKeeper,
			CentreBack,
			Sweeper,
			FullBack,
			WingBack,
			CentreMidfield,
			DefensiveMidfield,
			AttackingMidfield,
			WideMidfield,
			CentreForward,
			SecondStriker,
			Winger,
		};
		public static ReadOnlyCollection<PlayerPosition> AllPositions => _allPositions.AsReadOnly();
	}
}
