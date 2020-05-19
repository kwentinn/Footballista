using Footballista.BuildingBlocks.Domain;
using Footballista.Players.Features;
using Footballista.Players.Positions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Footballista.Players.Builders.Generators.FeatureGeneration.PlayerPositions
{
	public abstract class PlayerPositionGenerationRangeDefinition
	{
		private readonly PlayerPosition _position;

		protected List<GenRange> generationRanges = new List<GenRange>();

		protected static Range<Rating> MinRange => new Range<Rating>(Rating.FromInt(10), Rating.FromInt(40));
		protected static Range<Rating> MediumRange => new Range<Rating>(Rating.FromInt(20), Rating.FromInt(50));
		protected static Range<Rating> MaxRange => new Range<Rating>(Rating.FromInt(30), Rating.FromInt(65));


		public static PlayerPositionGenerationRangeDefinition GetFromPosition(PlayerPosition position)
		{
			if (position == PlayerPosition.Winger)
				return new WingerGenerationRangeDefinition(position);

			if (position == PlayerPosition.WideMidfield)
				return new WideMidfieldGenerationRangeDefinition(position);

			if (position == PlayerPosition.WingBack)
				return new WingBackGenerationRangeDefinition(position);

			if (position == PlayerPosition.Sweeper)
				return new SweeperGenerationRangeDefinition(position);

			if (position == PlayerPosition.SecondStriker)
				return new SecondStrikerGenerationRangeDefinition(position);

			if (position == PlayerPosition.GoalKeeper)
				return new GoalKeeperGenerationRangeDefinition(position);

			if (position == PlayerPosition.FullBack)
				return new FullBackGenerationRangeDefinition(position);

			if (position == PlayerPosition.DefensiveMidfield)
				return new DefensiveMidfieldGenerationRangeDefinition(position);

			if (position == PlayerPosition.DefensiveMidfield)
				return new DefensiveMidfieldGenerationRangeDefinition(position);

			if (position == PlayerPosition.CentreMidfield)
				return new CentreMidfieldGenerationRangeDefinition(position);

			if (position == PlayerPosition.CentreForward)
				return new CentreForwardGenerationRangeDefinition(position);

			if (position == PlayerPosition.CentreBack)
				return new CentreBackGenerationRangeDefinition(position);

			if (position == PlayerPosition.AttackingMidfield)
				return new AttackingMidfieldGenerationRangeDefinition(position);

			throw new InvalidOperationException("Position not found");
		}

		protected PlayerPositionGenerationRangeDefinition(PlayerPosition position)
		{
			this._position = position;
		}

		public ReadOnlyCollection<GenRange> GetGenerationRangeDefinitions()
		{
			return generationRanges.AsReadOnly();
		}
	}
}
