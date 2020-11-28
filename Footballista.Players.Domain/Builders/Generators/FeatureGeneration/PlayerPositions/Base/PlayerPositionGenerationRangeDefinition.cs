using Footballista.BuildingBlocks.Domain;
using Footballista.Players.Domain.Features;
using Footballista.Players.Domain.Positions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Footballista.Players.Domain.Builders.Generators.FeatureGeneration.PlayerPositions.Base
{
	public abstract class PlayerPositionGenerationRangeDefinition
	{
		protected readonly PlayerPosition Position;

		protected List<GenRange> GenerationRanges = new List<GenRange>();

		protected static Range<Rating> MinRange => new Range<Rating>(10, 40);
		protected static Range<Rating> MediumRange => new Range<Rating>(20, 50);
		protected static Range<Rating> MaxRange => new Range<Rating>(30, 65);


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
			Position = position;
		}

		public ReadOnlyCollection<GenRange> GetGenerationRangeDefinitions()
		{
			return GenerationRanges.AsReadOnly();
		}
	}
}
